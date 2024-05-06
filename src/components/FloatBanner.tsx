import { Box } from "@mui/material";
import { PropsWithChildren } from "react";
import { secondaryColor } from "../theme";

interface FloatBannerProps extends PropsWithChildren {
    reverse?: boolean;
    top?: number | string
}

const classes = {
    banner: (reverse?: boolean, top?: number | string) => ({
        position: "absolute",
        width: "80%",
        top: top || undefined,
        left: reverse ? 0 : undefined,
        right: reverse ? undefined : 0,
        borderRadius: reverse ? "0 20px 20px 0" : "20px 0 0 20px",
        boxShadow: "2px 11px 72px -1px rgba(3,6,10,0.53)",
        backgroundColor: secondaryColor
    })
}
const FloatBanner = ({ children, reverse, top }: FloatBannerProps) => {
    return (
        <Box sx={classes.banner(reverse, top)}>
            {children}
        </Box>
    )
}

export default FloatBanner;