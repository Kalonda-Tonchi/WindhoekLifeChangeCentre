import React, { useEffect } from "react";
import { connect } from "react-redux";
import {
    Grid,
    TextField,
    withStyles,
    InputLabel,
    FormControl,
    Select,
    MenuItem,
    Button,
    FormHelperText
} from "@material-ui/core";
import useForm from "./useForm";
import { create, update } from "../actions/Donations";
import { useToasts } from "react-toast-notifications";

const styles = (theme) => ({
    root: {
        "& .MuiTextField-root": {
            margin: theme.spacing(1),
            minWidth: 230
        }
    },
    formControl: {
        margin: theme.spacing(1),
        minWidth: 230
    },
    smMargin: {
        margin: theme.spacing(1)
    }
});

const DonationsForm = ({ classes, ...props }) => {
    const { addToast } = useToasts();

    const validate = (fieldValues = values) => {
        let temp = { ...errors };
        if ("name" in fieldValues)
            temp.name = fieldValues.name ? "" : "this field is required.";
        if ("nationality" in fieldValues)
            temp.nationality = fieldValues.nationality ? "" : "this field is required.";
        if ("gender" in fieldValues)
            temp.gender = fieldValues.gender
                ? ""
                : "this field is required.";
        if ("email" in fieldValues)
            temp.email = /^$|.+@.+..+/.test(fieldValues.email)
                ? ""
                : "Email is not valid.";
        setErrors({ ...temp });
        if (fieldValues === values)
            return Object.values(temp).every((x) => x === "");
    };
    const {
        values,
        setValues,
        onChangeHandler,
        setErrors,
        errors,
        resetForm
    } = useForm(props.setCurrentID, validate);

    const handleSubmit = (e) => {
        e.preventDefault();
        if (validate()) {
            const onSuccess = () => {
                resetForm();
                addToast("Submitted successfully", { appearance: "success" });
            };

            if (props.currentID === 0)
                props.createDCandidates(values, onSuccess);
            else props.updateDCandidates(props.currentID, values, onSuccess);
        }
    };

    useEffect(() => {
        if (props.currentID !== 0) {
            setValues({
                ...props.list.find((x) => x.id === props.currentID)
            });
            setErrors({});
        }
    }, [props.currentID]);

    return (
        <form
            autoComplete="off"
            noValidate
            className={classes.root}
            onSubmit={handleSubmit}
        >
            <Grid container>
                <Grid item xs={6}>
                    <TextField
                        name="name"
                        variant="outlined"
                        label="Full Name"
                        value={values.name}
                        onChange={onChangeHandler}
                        {...(errors.name && {
                            error: true,
                            helperText: errors.name
                        })}
                    ></TextField>
                    <TextField
                        name="email"
                        variant="outlined"
                        label="Email"
                        value={values.email}
                        onChange={onChangeHandler}
                        {...(errors.email && {
                            error: true,
                            helperText: errors.email
                        })}
                    ></TextField>
                    <FormControl
                        variant="outlined"
                        className={classes.formControl}
                        {...(errors.gender && {
                            error: true,
                            helperText: errors.gender
                        })}
                    >
                        <InputLabel>Blood Group</InputLabel>
                        <Select
                            name="gender"
                            value={values.gender}
                            onChange={onChangeHandler}
                        >
                            <MenuItem value="">Select Blood Gender</MenuItem>
                            <MenuItem value="F">A+</MenuItem>
                            <MenuItem value="M-">A-</MenuItem>
                           
                        </Select>
                        {errors.bloodGroup && (
                            <FormHelperText>{errors.gender}</FormHelperText>
                        )}
                    </FormControl>
                </Grid>
                <Grid item xs={6}>
                    <TextField
                        name="nationality"
                        variant="outlined"
                        label="Nationaliity"
                        value={values.nationality}
                        onChange={onChangeHandler}
                        {...(errors.nationality && {
                            error: true,
                            helperText: errors.nationality
                        })}
                    ></TextField>
                    <TextField
                        name="age"
                        variant="outlined"
                        label="Age"
                        value={values.age}
                        onChange={onChangeHandler}
                    ></TextField>
                    <TextField
                        name="address"
                        variant="outlined"
                        label="Address"
                        value={values.address}
                        onChange={onChangeHandler}
                    ></TextField>
                    <div>
                        <Button
                            variant="contained"
                            color="primary"
                            type="submit"
                            className={classes.smMargin}
                        >
                            Submit
                        </Button>
                        <Button
                            variant="contained"
                            className={classes.smMargin}
                            onClick={() => resetForm()}
                        >
                            Reset
                        </Button>
                    </div>
                </Grid>
            </Grid>
        </form>
    );
};

const mapStateToProps = (state) => ({
    ...state.dCandidateReducer
});

const mapActionToProps = {
    createDonors: create,
    updateDonors: update
};

export default connect(
    mapStateToProps,
    mapActionToProps
)(withStyles(styles)(DonationsForm));
