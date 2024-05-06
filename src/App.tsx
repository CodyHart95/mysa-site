import { BrowserRouter, Routes, Route } from "react-router-dom"
import Home from "./routes/Home"
import NavBar from "./components/NavBar"
import Shoots from "./routes/Shoots"
import { ThemeProvider } from "@mui/material"
import createAppTheme from "./theme"

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
      <BrowserRouter>
        <NavBar routes={routes}/>
        <Routes>
          {routes.map(r => (<Route key={r.path} path={r.path} element={r.component}/>))}
        </Routes>
      </BrowserRouter>
    </ThemeProvider>
  )
}

export default App
