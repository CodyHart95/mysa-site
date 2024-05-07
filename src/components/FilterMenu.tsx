import { Button, Menu, MenuItem, TextField } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { useCallback, useState } from "react";

export enum FilterMenuType {
    Search,
    Date
}

interface FilterMenuProps {
    open: boolean;
    setOpen: (val: boolean) => void;
    onFilter: (val: any) => void;
    menuType: FilterMenuType;
    anchorEl: any;
}

interface SearchComponentProps {
    menuType: FilterMenuType;
    value: any;
    setValue: (val: any) => void;
}

const classes = {
    searchComponent: {
        width: "250px"
    }
}
const SearchComponent = ({ menuType, value, setValue }: SearchComponentProps) => {
    if(menuType === FilterMenuType.Date) {
        return <DatePicker sx={classes.searchComponent} value={value} onChange={setValue}/>
    }

    return <TextField sx={classes.searchComponent} value={value} onChange={setValue} placeholder="Search..."/>
}

const FilterMenu = ({ open, setOpen, onFilter, menuType, anchorEl }: FilterMenuProps) => {
    const [filterValue, setFilterValue] = useState();

    const onFilterInternal = useCallback(() => {
        setOpen(false);
        onFilter(filterValue);
    }, [setOpen, onFilter, filterValue])


    return (
        <Menu open={open} onClose={() => setOpen(false)} anchorEl={anchorEl}>
            <MenuItem>
                <SearchComponent menuType={menuType} value={filterValue} setValue={setFilterValue}/>
            </MenuItem>
            <MenuItem>
                <Button variant="contained" color="secondary" onClick={onFilterInternal}>Filter</Button>
            </MenuItem>
        </Menu>
    )
};

export default FilterMenu;