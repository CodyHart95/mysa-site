import { Box, IconButton, TableCell } from "@mui/material";
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import { PropsWithChildren, useCallback, useState } from "react";
import FilterMenu, { FilterMenuType } from "./FilterMenu";

const classes = {
    headerCell: {
        fontWeight: "bold",
        borderRight: "1px solid rgb(224, 224, 224)",
    }
}

interface FilterHeaderCell extends PropsWithChildren {
    onFilterSelected: (filterColumn: string) => void;
    filterType?: FilterMenuType;
}

const FilterHeaderCell = ({ onFilterSelected, children, filterType = FilterMenuType.Search }: FilterHeaderCell) => {
    const [menuAnchor, setMenuAnchor] = useState<any>(null);

    const onOpen = useCallback((event: React.MouseEvent<HTMLButtonElement>) => {
        setMenuAnchor(event.currentTarget)
    }, []);

    const onFilter = useCallback((value: any) => {
        setMenuAnchor(false);
        onFilterSelected(value);
    }, [onFilterSelected]);

    return (
        <TableCell sx={classes.headerCell}>
            <Box display="flex" alignItems="center" justifyContent="space-between">
                {children}
                <IconButton onClick={onOpen}>
                    <FilterAltIcon/>
                </IconButton>
            </Box>
            <FilterMenu open={menuAnchor} setOpen={() => setMenuAnchor(null)} onFilter={onFilter} menuType={filterType} anchorEl={menuAnchor}/>
        </TableCell>
    )
}

export default FilterHeaderCell;