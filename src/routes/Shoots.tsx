import {  Table, TableBody, TableCell, TableHead, TableRow, Typography } from "@mui/material";
import FilterHeaderCell from "../components/FilterHeaderCell";
import { FilterMenuType } from "../components/FilterMenu";
import { useEffect, useState } from "react";
import EmptyTableBody from "../components/EmptyTableBody";


const Shoots = () => {
    const [shoots, setShoots] = useState<Shoot[]>();
    
    const onFilter = (filterColumn: string) => {
        console.log(filterColumn)
    }

    useEffect(() => {
        // TODO: Make Api Call instead

        const mockShoots: Shoot[] = []
            for(let i = 0; i < 10; i++) {
                mockShoots.push({
                    name: `Test Shoot ${i}`,
                    clubName: "My House",
                    date: new Date(Date.now()),
                    city: "Manchester",
                    state: "MO",
                    shootId: i.toString()
                })
            }
    
            setShoots(mockShoots)
    }, [])

    return (
        <>
        <Table>
            <TableHead>
                <TableRow>
                    <FilterHeaderCell onFilterSelected={onFilter}>
                        <Typography variant="h4">Name</Typography>
                    </FilterHeaderCell>
                    <FilterHeaderCell onFilterSelected={onFilter}>
                        <Typography variant="h4">Club</Typography>
                    </FilterHeaderCell>
                    <FilterHeaderCell onFilterSelected={onFilter}>
                        <Typography variant="h4">City</Typography>
                    </FilterHeaderCell>
                    <FilterHeaderCell onFilterSelected={onFilter}>
                        <Typography variant="h4">State</Typography>
                    </FilterHeaderCell>
                    <FilterHeaderCell onFilterSelected={onFilter} filterType={FilterMenuType.Date}>
                        <Typography variant="h4">ShootDate</Typography>
                    </FilterHeaderCell>
                </TableRow>
            </TableHead>
                {
                shoots &&  
                    <TableBody>
                        {
                            shoots.map(s => (
                                <TableRow>
                                    <TableCell>
                                        <Typography>{s.name}</Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography>{s.clubName}</Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography>{s.city}</Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography>{s.state}</Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography>{s.date.toDateString()}</Typography>
                                    </TableCell>
                                </TableRow>
                            ))
                        }
                    </TableBody>
                }
        </Table>
        {!shoots && <EmptyTableBody/>}
        </>
    )
}

export default Shoots;