import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./routes/Home";
import NavBar from "./components/NavBar";
import Shoots from "./routes/Shoots";
import { ThemeProvider } from "@mui/material";
import createAppTheme from "./theme";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';

const theme = createAppTheme();
const routes = [
  {
    path: "/",
    title: "Home",
    component: <Home/>
  },
  {
    path: "/shoots",
    title: "Shoots",
    component: <Shoots/>
  }
]

function App() {
  return (
    <ThemeProvider theme={theme}>
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <BrowserRouter>
          <NavBar routes={routes}/>
          <Routes>
            {routes.map(r => (<Route key={r.path} path={r.path} element={r.component}/>))}
          </Routes>
        </BrowserRouter>
      </LocalizationProvider>
    </ThemeProvider>
  )
}

export default App
