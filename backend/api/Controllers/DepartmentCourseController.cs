using api.DTO.DeparmentCourse;
using api.DTO.DepartmentCourse;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentCourseController: ControllerBase
    {
        private readonly IDepartmentCourseRepository _departmentCourseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseDetailsRepository _courseDetailsRepository;
        private readonly ISemesterDetailsRepository _semesterDetailsRepository;
        public DepartmentCourseController(
            IDepartmentCourseRepository courseDepRepository, IDepartmentRepository departmentRepository, 
            ICourseRepository courseRepository, ICourseDetailsRepository courseDetailsRepository, 
            ISemesterDetailsRepository semesterDetailsRepository){
            _departmentCourseRepository = courseDepRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _courseDetailsRepository = courseDetailsRepository;
            _semesterDetailsRepository = semesterDetailsRepository;
        }

        [HttpGet("University/Faculty/Department/Course/")]
        public async Task<IActionResult> GetDepCourseByCourseAndDepName([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var course = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(course == null){
                return NotFound();
            }

            return Ok(course.ToDepartmentCourseDto());
        }
        [HttpGet("University/Faculty/Department/Semester/Courses/")]
        public async Task<IActionResult> GetActiveDepCoursesBySemester([FromQuery] String DepName, [FromQuery] String Level,[FromQuery] int Semester){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courses = await _departmentCourseRepository.GetDepartmentSemesterCoursesAsync(DepName, Level, Semester);

            if(courses == null){
                return NotFound();
            }

            return Ok(courses.ToDepartmentCourseDto());
        }
        [HttpGet("University/Faculty/Departments/Course")]
        public async Task<IActionResult> GetDepartmentsOfCourse([FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courses = await _departmentCourseRepository.GetDepartmentsOfCourseByCourseNameAsync(CourseName);

            if(courses == null){
                return NotFound();
            }

            return Ok(courses.ToDepartmentCourseDto());
        }
        [HttpGet("University/Faculty/Department/Courses/")]
        public async Task<IActionResult> GetCoursesOfDepartment([FromQuery] String DepName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var courses = await _departmentCourseRepository.GetDepartmentCoursesAsync(DepName);

            if(courses == null){
                return NotFound();
            }

            return Ok(courses.ToDepartmentCourseDto());
        }
        [HttpPost("University/Faculty/Department/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseToDepartment([FromBody] DepartmentCoursePostDto coursePostDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var validDepartment = await _departmentRepository.GetDepartmentAsync(coursePostDto.DepartmentName);

            if(validDepartment == null){
                return NotFound("Department not found!");
            }

            var validCourse = await _courseRepository.GetCourseAsync(coursePostDto.CourseName);

            if(validCourse == null){
                return NotFound("Course not found!");
            }

            var courseDetails = await _courseDetailsRepository.GetCourseDetailsAsync(coursePostDto.CourseDetailsId);
            if(courseDetails == null){
                return NotFound("Course Details not found");
            } 

            if(courseDetails.CourseName != coursePostDto.CourseName){
                return BadRequest("Course Details and Course Name doesn't match.");
            }

            var SemesterDetail = await _semesterDetailsRepository.GetSemesterDetailsAsync(coursePostDto.DepartmentName, coursePostDto.TaughtSemester);
            if(SemesterDetail == null){
                return NotFound("Semester Details not found. Either that semester doesn't exist or its info is not posted yet.");
            }
            int academicYear = (coursePostDto.TaughtSemester + 1) / 2;
            int totalCourses = await _semesterDetailsRepository.GetNumOfCoursesInAcademicYear(academicYear);

            if(totalCourses == -1){
                return NotFound("No semester details on the specified academic year.");
            }
            int code = academicYear*1000 + totalCourses + 1;
            String CourseCode = validDepartment.DepCode + "-" + code.ToString();

            var depsDetails = await _departmentCourseRepository.AddCourseToDepAsync(coursePostDto.ToDepartmentCourse(CourseCode));
            
            if(depsDetails == null){
                return BadRequest();
            }
            
            SemesterDetail.TotalCourses++;
            var result = await _semesterDetailsRepository.UpdateSemesterDetailsAsync(SemesterDetail);

            if(result == null){
                return StatusCode(500, "Failed to increment semester courses.");
            }

            return Ok(depsDetails.ToDepartmentCourseDto());
        }
        [HttpPut("University/Faculty/Department/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseOfDepartment([FromQuery] String DepName, [FromQuery] String CourseName, [FromBody] DepartmentCourseUpdateDto departmentCourseUpdateDto){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(departmentCourseUpdateDto.CourseName != CourseName || departmentCourseUpdateDto.DepartmentName != DepName){
                return BadRequest();
            }

            if(departmentCourseUpdateDto.Status != "Open" && departmentCourseUpdateDto.Status != "Closed"){
                return BadRequest("Status can only be Open or Closed");
            }

            var SemesterDetail = await _semesterDetailsRepository.GetSemesterDetailsAsync(departmentCourseUpdateDto.DepartmentName, departmentCourseUpdateDto.TaughtSemester);
            if(SemesterDetail == null){
                return NotFound("Semester Details not found. Either that semester doesn't exist or its info is not posted yet. Failed to Update the Course.");
            }

            var depCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(depCourse == null){
                return BadRequest();
            }

            depCourse.TaughtSemester = departmentCourseUpdateDto.TaughtSemester;
            depCourse.Status = departmentCourseUpdateDto.Status;
            depCourse.CourseDetailsId = departmentCourseUpdateDto.CourseDetailsId;
            
            var updatedDepCourse = await _departmentCourseRepository.UpdateDepsCourseAsync(depCourse);
            
            if(updatedDepCourse == null){
                return StatusCode(500);
            }

            return Ok(updatedDepCourse.ToDepartmentCourseDto());
        }
        [HttpDelete("University/Faculty/Deparment/Course")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourseOfDepartment([FromQuery] String DepName, [FromQuery] String CourseName){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validCourse = await _departmentCourseRepository.GetDeparmentCourseAsync(CourseName, DepName);

            if(validCourse == null){
                return NotFound();
            }
            
            var SemesterDetail = await _semesterDetailsRepository.GetSemesterDetailsAsync(validCourse.DepartmentName, validCourse.TaughtSemester);
            if(SemesterDetail == null){
                return NotFound("Semester Details not found. Either that semester doesn't exist or its info is not posted yet. Failed to Delete the Course.");
            }
            // Should not decrese because CourseCode depends on it 
            /*
            SemesterDetail.TotalCourses--;
            var result = await _semesterDetailsRepository.UpdateSemesterDetailsAsync(SemesterDetail);

            if(result == null){
                return StatusCode(500, "Failed to decrease semester courses. Aborting course deletion.");
            }
            */

            var deletionResult = await _departmentCourseRepository.DeleteCourseFromDepAsync(CourseName, DepName);

            if(deletionResult == null){
                return BadRequest();
            }

            return NoContent();
        }
        
    }
}