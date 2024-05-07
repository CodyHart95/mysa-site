import { Box, Typography } from "@mui/material";

const classes = {
    body: {
        width: "100%",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        position: "absolute",
        top: "50%"
    }
}
const EmptyTableBody = () => {
    return (
        <Box sx={classes.body}>
            <Typography variant="h3">No Data to Display</Typography>
        </Box>
    )
};

export default EmptyTableBody;