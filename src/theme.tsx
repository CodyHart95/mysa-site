import { createTheme } from "@mui/material";

export const primaryColor = "#D90425";
export const secondaryColor = "#063283";
const textPrimary = "#45505B";

export const Theme = {
    palette: {
        primary: {
            main: primaryColor,
            secondary: secondaryColor
        },
        secondary: {
            main: secondaryColor
        },
        text: {
            primary: textPrimary,
            secondaryColor: primaryColor
        }
    },
    typography: {
        fontFamily: "Roboto",
        fontSize: 14,
        h1: { fontSize: "4em", fontWeight: "bold", color: textPrimary },
        h2: { fontSize: "3em", color: textPrimary },
        h3: { fontSize: "2em", fontWeight: "bold", color: textPrimary },
        body1: { fontSize: "14px", fontWeight: 400, color: textPrimary },
        body2: { fontSize: "12px", fontWeight: 400, color: "#637381" },
        button: {
            textTransform: "none",
        },
    },
    components: {
        MuiButton: {
            variants: [
                {
                    props: { variant: "contained" },
                    style: {
                        borderRadius: "4px",
                        fontSize: "14px",
                        fontWeight: "500",
                        color: "white",
                        padding: "8px",
                        minWidth: "80px",
                    },
                },
                {
                    props: { variant: "outlined" },
                    style: {
                        fontSize: "14px",
                        borderRadius: "5px",
                        height: "40px",
                        color: primaryColor,
                        border: `1px solid ${primaryColor}`,
                    },
                },
            ],
        },
        MuiPaper: {
            styleOverrides: {
                elevation1: {
                    boxShadow: "0px 1px 1px 0.5px rgb(46 91 255 / 15%)",
                },
            },
        },
    },
} 


//@ts-expect-error were overriding the theme
const createAppTheme = () => createTheme(Theme);
export default createAppTheme;