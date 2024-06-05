import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { Box, Typography, Button } from "@mui/material";

import Logo from "assets/logo";
import { ReactComponent as Line } from "assets/line.svg";
import { ReactComponent as DevletLogo } from "assets/e-devlet-logo.svg";

import TextField from "@mui/material/TextField";
import IconButton from "@mui/material/IconButton";
import InputLabel from "@mui/material/InputLabel";
import FormControl from "@mui/material/FormControl";
import FilledInput from "@mui/material/FilledInput";
import Visibility from "@mui/icons-material/Visibility";
import InputAdornment from "@mui/material/InputAdornment";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import CircularProgress from "@mui/material/CircularProgress";

import { useDispatch } from "react-redux";
import { setUserToken, setUserData } from "store/user/user.action";
import { setProgram } from "store/program/program.action";
import { ToastContainer, toast } from "react-toastify";

const INITIAL_STATE = {
  username: "",
  password: "",
};

const PORT = 53675; //!--- Change this to your port number

const Login = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const [userInput, setUserInput] = useState(INITIAL_STATE);
  const { username, password } = userInput;
  const [showPassword, setShowPassword] = useState(false);
  const [loading, setLoading] = useState(false);

  const handleClickShowPassword = () => setShowPassword((show) => !show);

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  const handleInputChange = (e) => {
    e.preventDefault();
    const { name, value } = e.target;
    setUserInput({
      ...userInput,
      [name]: value,
    });
  };

  const handleOnSubmit = async (e) => {
    e.preventDefault();
    try {
      setLoading(true);
      const response = await axios.post(
        `https://localhost:${PORT}/api/System/Account/LogIn`,
        userInput
      );
      console.log();

      dispatch(setUserToken(response.data.token));
      dispatch(setUserData(response.data.data));
      dispatch(setProgram(response.data.data.departments[0].departmentName))
      localStorage.setItem("userData", JSON.stringify(response.data.data));
      localStorage.setItem("token", response.data.token);
      localStorage.setItem("program",response.data.data.departments[0].departmentName)

      resetInputValue();
      navigate("/home");
    } catch (error) {
      toast.error(error.response.data,{
        position:"top-right",
      })
    }
    setLoading(false);
  };

  const handleDevletButton = async (e) => {
    e.preventDefault();
    dispatch(setUserToken(userInput));
    resetInputValue();
    navigate("/home");
  };

  const resetInputValue = () => {
    setUserInput(INITIAL_STATE);
  };

  const canNotLogin = (e) => {
    e.preventDefault();
    alert("We are useless and can't help you.");
  };

  return (
    <Box
      sx={{
        paddingX: "70px",
        width: "100%",
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-around",
        alignItems: "center",
      }}
    >
      <Logo width="250px" />
      <Box>
        <Box
          width={"300px"}
          display={"flex"}
          alignItems="center"
          justifyContent="center"
          flexDirection={"column"}
        >
          {/* TC and Password Inputs */}
          <form onSubmit={handleOnSubmit}>
            <div>
              <TextField
                required
                id="username"
                name="username"
                type="username"
                fullWidth={true}
                style={{ marginBottom: "15px" }}
                label="Kimlik numarası"
                variant="filled"
                onChange={handleInputChange}
                value={username}
              />
              <FormControl
                fullWidth={true}
                style={{ marginBottom: "15px" }}
                variant="filled"
              >
                <InputLabel htmlFor="filled-adornment-password">
                  Parola
                </InputLabel>
                <FilledInput
                  required
                  onChange={handleInputChange}
                  value={password}
                  id="filled-adornment-password"
                  name="password"
                  type={showPassword ? "text" : "password"}
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                        edge="end"
                      >
                        {showPassword ? <Visibility /> : <VisibilityOff />}
                      </IconButton>
                    </InputAdornment>
                  }
                />
              </FormControl>
            </div>
            <Button
              type="submit"
              size="large"
              variant="contained"
              style={{
                height: "50px",
                borderRadius: "12px",
                marginTop: "60px",
              }}
              fullWidth={true}
            >
              {loading ? (
                <CircularProgress color="inherit" size={24} />
              ) : (
                "Giriş Yap"
              )}
            </Button>
          </form>
        </Box>
        <Box width={"300px"}>
          <Box
            m={1}
            display="flex"
            alignItems={"center"}
            justifyContent={"space-between"}
          >
            <Line />{" "}
            <p
              style={{
                fontSize: "10px",
                fontWeight: 300,
                color: "rgba(0, 0, 0, 0.50)",
              }}
            >
              or continue
            </p>
            <Line />
          </Box>
          <Button
            onClick={handleDevletButton}
            sx={{
              height: "50px",
              borderRadius: "12px",
              color: "black",
              borderColor: "black",
              "&:hover": {
                borderColor: "black",
              },
            }}
            startIcon={<DevletLogo />}
            size="large"
            variant="outlined"
            fullWidth={true}
          >
            e-Devlet ile giriş
          </Button>
        </Box>
        <Box
          mt={3}
          sx={{
            display: "flex",
            justifyContent: "center",
          }}
        >
          <Typography
            onClick={canNotLogin}
            sx={{
              cursor: "pointer",
              opacity: "0.75",
              "&:hover": { opacity: 1 },
            }}
            variant="subtitle2"
          >
            Giriş yapamıyor musunuz?
          </Typography>
        </Box>
      </Box>
      <ToastContainer/>
    </Box>
  );
};

export default Login;
