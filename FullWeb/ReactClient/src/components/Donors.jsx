import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import { fetchAll, Delete } from "../actions/Donations";
import {
    Grid,
    Paper,
    TableCell,
    TableContainer,
    Table,
    TableHead,
    TableBody,
    TableRow,
    withStyles,
    Button,
    ButtonGroup
} from "@material-ui/core";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import DCandidateForm from "./DonationsForm";
import { useToasts } from "react-toast-notifications";

const styles = (theme) => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }
});

const DCandidates = ({ classes, ...props }) => {
    

    const [currentID, setCurrentID] = useState(0);

    const { addToast } = useToasts();
    useEffect(() => {
        props.fetchAllDCandidates();
    }, [props]); //componentDidMount

    const supprimer = (id) => {
        props.deleteDCandidates(id, () =>
            addToast("Deleted successfully", { appearance: "info" })
        );
    };

    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={6}>
                    <DonationsForm {...{ currentID, setCurrentID }} />
                </Grid>
                <Grid item xs={6}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>Nationality</TableCell>
                                    <TableCell>Gender</TableCell>
                                    <TableCell>Actions</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {props.list.map((c, i) => {
                                    return (
                                        <TableRow key={i} hover>
                                            <TableCell>{c.name}</TableCell>
                                            <TableCell>{c.nationality}</TableCell>
                                            <TableCell>
                                                {c.bloodGroup}
                                            </TableCell>
                                            <TableCell>
                                                <ButtonGroup variant="text">
                                                    <Button>
                                                        <EditIcon
                                                            color="primary"
                                                            onClick={() =>
                                                                {setCurrentID(c.id)}
                                                            }
                                                        />
                                                    </Button>
                                                    <Button>
                                                        <DeleteIcon
                                                            color="secondary"
                                                            onClick={() =>
                                                                supprimer(c.id)
                                                            }
                                                        />
                                                    </Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>
                                    );
                                })}
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
    );
};

const mapStateToProps = (state) => ({
    ...state.donoreReducer
});

/*const mapDispatchToProps = () => ({
    fetchAll
});*/

const mapActionToProps = {
    readDonors: Read,
    deleteDonors: Delete
};

export default connect(
    mapStateToProps,
    mapActionToProps
)(withStyles(styles)(Donors));
