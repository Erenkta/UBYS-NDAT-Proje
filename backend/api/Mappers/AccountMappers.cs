using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.AccountInfo;
using api.Models;

namespace api.Mappers
{
    public static class AccountMappers
    {
        // StudentAccountMappers
        public static StudentAccountDto ToStudentAccountDto(this StudentAccount studentAcc){
            return new StudentAccountDto{
                FirstName = studentAcc.FirstName,
                LastName = studentAcc.LastName,
                BirthDate = studentAcc.BirthDate,
                SSN = studentAcc.SSN,
                RegisterDate = studentAcc.RegisterDate,
                CurrentType = studentAcc.CurrentType,
                CurrentStatus = studentAcc.CurrentStatus,
                SchoolMail = studentAcc.SchoolMail,
                PersonalMail = studentAcc.PersonalMail,
                Phone = studentAcc.Phone
            };
        }
        public static StudentAccountLOGINDto ToStudentAccountLOGINDto(this StudentAccount studentAcc){
            return new StudentAccountLOGINDto{
                Role = "Student",
                FirstName = studentAcc.FirstName,
                LastName = studentAcc.LastName,
                BirthDate = studentAcc.BirthDate,
                SSN = studentAcc.SSN,
                RegisterDate = studentAcc.RegisterDate,
                CurrentType = studentAcc.CurrentType,
                CurrentStatus = studentAcc.CurrentStatus,
                SchoolMail = studentAcc.SchoolMail,
                PersonalMail = studentAcc.PersonalMail,
                Phone = studentAcc.Phone
            };
        }
        public static StudentAccount POSTToStudentAccount(this StudentAccountPOSTDto newStudentAcc){
            return new StudentAccount{
                FirstName = newStudentAcc.FirstName,
                LastName = newStudentAcc.LastName,
                BirthDate = newStudentAcc.BirthDate,
                SSN = newStudentAcc.SSN,
                RegisterDate = DateTime.Now,
                CurrentType = newStudentAcc.CurrentType,
                CurrentStatus = newStudentAcc.CurrentStatus,
                SchoolMail = newStudentAcc.SchoolMail,
                PersonalMail = newStudentAcc.PersonalMail,
                Phone = newStudentAcc.Phone,
                UserId = newStudentAcc.UserId
            };
        }


        // LecturerAccountMappers
        public static LecturerAccountDto ToLecturerAccountDto(this LecturerAccount LecturerAcc){
            return new LecturerAccountDto{
                FirstName = LecturerAcc.FirstName,
                LastName = LecturerAcc.LastName,
                BirthDate = LecturerAcc.BirthDate,
                LecturerId = LecturerAcc.LecturerId,
                RegisterDate = LecturerAcc.RegisterDate,
                Title = LecturerAcc.Title,
                CurrentStatus = LecturerAcc.CurrentStatus,
                TotalWorkHours = LecturerAcc.TotalWorkHours,
                SchoolMail = LecturerAcc.SchoolMail,
                PersonalMail = LecturerAcc.PersonalMail,
                Phone = LecturerAcc.Phone
            };
        }
        public static LecturerAccountLOGINDto ToLecturerAccountLOGINDto(this LecturerAccount LecturerAcc){
            return new LecturerAccountLOGINDto{
                Role = "Lecturer",
                FirstName = LecturerAcc.FirstName,
                LastName = LecturerAcc.LastName,
                BirthDate = LecturerAcc.BirthDate,
                LecturerId = LecturerAcc.LecturerId,
                RegisterDate = LecturerAcc.RegisterDate,
                Title = LecturerAcc.Title,
                CurrentStatus = LecturerAcc.CurrentStatus,
                TotalWorkHours = LecturerAcc.TotalWorkHours,
                SchoolMail = LecturerAcc.SchoolMail,
                PersonalMail = LecturerAcc.PersonalMail,
                Phone = LecturerAcc.Phone
            };
        }

        public static LecturerAccount POSTToLecturerAccount(this LecturerAccountPOSTDto newLecturerAcc){
            return new LecturerAccount{
                FirstName = newLecturerAcc.FirstName,
                LastName = newLecturerAcc.LastName,
                BirthDate = newLecturerAcc.BirthDate,
                LecturerId = newLecturerAcc.LecturerId,
                RegisterDate = DateTime.Now,
                Title = newLecturerAcc.Title,
                CurrentStatus = newLecturerAcc.CurrentStatus,
                TotalWorkHours = newLecturerAcc.TotalWorkHours,
                SchoolMail = newLecturerAcc.SchoolMail,
                PersonalMail = newLecturerAcc.PersonalMail,
                Phone = newLecturerAcc.Phone,
                UserId = newLecturerAcc.UserId
            };
        }

        // AdvisorAccountMappers
        public static AdvisorAccountDto ToAdvisorAccountDto(this AdvisorAccount AdvisorAcc){
            return new AdvisorAccountDto{
                FirstName = AdvisorAcc.FirstName,
                LastName = AdvisorAcc.LastName,
                BirthDate = AdvisorAcc.BirthDate,
                AdvisorId = AdvisorAcc.AdvisorSSN,
                RegisterDate = AdvisorAcc.RegisterDate,
                //CurrentType = AdvisorAcc.CurrentType,
                //CurrentStatus = AdvisorAcc.CurrentStatus,
                SchoolMail = AdvisorAcc.SchoolMail,
                PersonalMail = AdvisorAcc.PersonalMail,
                Phone = AdvisorAcc.Phone
            };
        }

         public static AdvisorAccountLOGINDto ToAdvisorAccountLOGINDto(this AdvisorAccount AdvisorAcc){
            return new AdvisorAccountLOGINDto{
                Role = "Advisor",
                FirstName = AdvisorAcc.FirstName,
                LastName = AdvisorAcc.LastName,
                BirthDate = AdvisorAcc.BirthDate,
                AdvisorId = AdvisorAcc.AdvisorSSN,
                RegisterDate = AdvisorAcc.RegisterDate,
                //CurrentType = AdvisorAcc.CurrentType,
                //CurrentStatus = AdvisorAcc.CurrentStatus,
                SchoolMail = AdvisorAcc.SchoolMail,
                PersonalMail = AdvisorAcc.PersonalMail,
                Phone = AdvisorAcc.Phone
            };
        }

        public static AdvisorAccount POSTToAdvisorAccount(this AdvisorAccountPOSTDto newAdvisorAcc){
            return new AdvisorAccount{
                FirstName = newAdvisorAcc.FirstName,
                LastName = newAdvisorAcc.LastName,
                BirthDate = newAdvisorAcc.BirthDate,
                AdvisorSSN = newAdvisorAcc.AdvisorId,
                RegisterDate = DateTime.Now,
                //CurrentType = newAdvisorAcc.CurrentType,
                //CurrentStatus = newAdvisorAcc.CurrentStatus,
                SchoolMail = newAdvisorAcc.SchoolMail,
                PersonalMail = newAdvisorAcc.PersonalMail,
                Phone = newAdvisorAcc.Phone,
                UserId = newAdvisorAcc.UserId
            };
        }

        //AdministratorAccountMappers
        public static AdministratorAccountDto ToAdministratorAccountDto(this AdministratorAccount AdministratorAcc){
            return new AdministratorAccountDto{
                FirstName = AdministratorAcc.FirstName,
                LastName = AdministratorAcc.LastName,
                BirthDate = AdministratorAcc.BirthDate,
                AdministratorId = AdministratorAcc.AdministratorId,
                RegisterDate = AdministratorAcc.RegisterDate,
                //CurrentType = AdministratorAcc.CurrentType,
                //CurrentStatus = AdministratorAcc.CurrentStatus,
                SchoolMail = AdministratorAcc.SchoolMail,
                PersonalMail = AdministratorAcc.PersonalMail,
                Phone = AdministratorAcc.Phone
            };
        }

         public static AdministratorAccountLOGINDto ToAdministratorAccountLOGINDto(this AdministratorAccount AdministratorAcc){
            return new AdministratorAccountLOGINDto{
                Role = "Administrator",
                FirstName = AdministratorAcc.FirstName,
                LastName = AdministratorAcc.LastName,
                BirthDate = AdministratorAcc.BirthDate,
                AdministratorId = AdministratorAcc.AdministratorId,
                RegisterDate = AdministratorAcc.RegisterDate,
                //CurrentType = AdministratorAcc.CurrentType,
                //CurrentStatus = AdministratorAcc.CurrentStatus,
                SchoolMail = AdministratorAcc.SchoolMail,
                PersonalMail = AdministratorAcc.PersonalMail,
                Phone = AdministratorAcc.Phone
            };
        }

        public static AdministratorAccount POSTToAdministratorAccount(this AdministratorAccountPOSTDto newAdministratorAcc){
            return new AdministratorAccount{
                FirstName = newAdministratorAcc.FirstName,
                LastName = newAdministratorAcc.LastName,
                BirthDate = newAdministratorAcc.BirthDate,
                AdministratorId = newAdministratorAcc.AdministratorId,
                RegisterDate = DateTime.Now,
                //CurrentType = newAdministratorAcc.CurrentType,
                //CurrentStatus = newAdministratorAcc.CurrentStatus,
                SchoolMail = newAdministratorAcc.SchoolMail,
                PersonalMail = newAdministratorAcc.PersonalMail,
                Phone = newAdministratorAcc.Phone,
                UserId = newAdministratorAcc.UserId
            };
        }

    }
}