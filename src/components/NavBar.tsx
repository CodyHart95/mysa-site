import { Box, styled, Link } from "@mui/material"
import logo  from "../assets/mysa-logo.webp";
import { useNavigate } from "react-router-dom";
import { secondaryColor } from "../theme";

interface Route {
    path: string;
    title: string;
    subRoutes?: Route[];
}
interface NavBarProps {
    routes: Route[]
}

const HomeImage = styled("img")({
    width: "100px",
    margin: "8px",
    "&:hover": {
        cursor: "pointer"
    }
})

const classes = {
    container: {
        display: "flex",
        alignItems: "center",
        justifyContent: "space-between",
        width: "100%",
        borderBottom: "1px solid lightGray",
    },
    link: {
        textDecoration: "none",
        marginRight: "8px",
        color: secondaryColor,
        "&:hover": {
            cursor: "pointer"
        }
    },
    routeContainer: {
        marginRight: "48px"
    }
}

const NavBar = ({ routes }: NavBarProps) => {

    const navigate = useNavigate();

    return (
        <Box sx={classes.container}>
            <HomeImage src={logo} onClick={() => navigate("/")} />
            <Box sx={classes.routeContainer}>
                {routes.map(route => (
                    <Link sx={classes.link} color="secondary" key={route.path} href={route.path}>{route.title}</Link>
                ))}
            </Box>
        </Box>
    )
}

export default NavBar;