import { Box, Button, Typography, styled } from "@mui/material";
import Hero from "../assets/hero.webp";
import Logo from "../assets/mysa-logo.webp";
import FloatBanner from "../components/FloatBanner";
import AssessmentIcon from '@mui/icons-material/Assessment';
import Groups2Icon from '@mui/icons-material/Groups2';
import ArticleIcon from '@mui/icons-material/Article';

const LogoHeader = styled("img")({
    width: "15%",
    marginLeft: "25%"
});

const classes = {
    container: {
        position: "relative",
        width: "100%",
        height: "70vh",
    },
    overlay: {
        position: "absolute",
        top: 0,
        left: 0,
        width: "100%",
        height: "100%",
        backgroundImage: `url(${Hero})`,
        opacity: "40%",
        backgroundSize: "cover",
        borderTop: "1px solid #919191",
        borderBottom: "1px solid #919191",
    },
    content: {
        position: "relative",
        width: "100%",
        height: "100%",
        display: "flex",
        alignItems: "center",
        justifyContent: "space-between"
    },
    darken: {
        position: "absolute",
        top: 0,
        left: 0,
        width: "100%",
        height: "100%",
        backgroundColor: "rgba(0, 0, 0, 0.5)"
    },
    shootsButton: {
        marginLeft: "16px"
    },
    buttonContainer: {
        marginTop: "24px"
    },
    subHeader: {
        marginTop: "16px"
    },
    icon: {
        color: "white",
        fontSize: "50px"
    },
    iconLinkContainer: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        "&:hover": {
            cursor: "pointer"
        }
    }
}
const Home = () => {

    return (
        <div>
            <Box sx={classes.container}>
                <Box sx={classes.overlay}/>
                <Box sx={classes.darken}/>
                <Box sx={classes.content}>
                    <LogoHeader src={Logo}/>
                    <Box width="50%">
                        <Typography variant="h1" color="white">Missouri Youth Shooting Sports Management</Typography>
                        <Typography sx={classes.subHeader} color="white" variant="h3">Manage shooters, scores and reporting for Missouri Youth Shooters</Typography>
                        <Box sx={classes.buttonContainer}>
                            <Button variant="contained">View Scores</Button>
                            <Button variant="contained" color="secondary" sx={classes.shootsButton}>Upcoming Shoots</Button>
                        </Box>
                    </Box>
                </Box>
            </Box>
            <FloatBanner top="73vh">
                <Box display="flex" alignItems="center" justifyContent="space-evenly" height="200px">
                    <Box sx={classes.iconLinkContainer}>
                        <AssessmentIcon sx={classes.icon}/>
                        <Typography variant="h3" color="white">Live Scores</Typography>
                    </Box>
                    <Box sx={classes.iconLinkContainer}>
                        <Groups2Icon sx={classes.icon}/>
                        <Typography variant="h3" color="white">Squadding</Typography>
                    </Box>
                    <Box sx={classes.iconLinkContainer}>
                        <ArticleIcon sx={classes.icon}/>
                        <Typography variant="h3" color="white">Shoot Details</Typography>
                    </Box>
                </Box>
            </FloatBanner>
            {/** TODO: ADD MORE STUFF HERE TO FILL OUT PAGE */}
        </div>
    )
}

export default Home;