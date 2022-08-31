import { TextField } from '@mui/material'
import React from 'react'


export default function Input(props) {

    const {label , name , variant , value , onChange , error = null , ...other}= props;

  return (
  <TextField
        style={{width:'90%',margin:"8px"}}
        variant={variant || 'outlined'}
        label={label}
        value={value}
        onChange={onChange}
        name={name}
        {...other}
        {...(error && {error  :true, helperText : error})}
  />
  )
}
