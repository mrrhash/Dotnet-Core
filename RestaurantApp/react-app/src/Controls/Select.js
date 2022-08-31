import { FormControl, FormHelperText, InputLabel,MenuItem,Select as MuiSelect } from '@mui/material';
import React from 'react'

export default function Select(props) {

    const {name , value , variant , options , onChange , label , error = null} = props;

  return (
    <FormControl
    style={{width:'90%',margin:"8px"}}
    variant={variant || 'outlined'}
    {...(error && {error : true})}>
        <InputLabel>{label}</InputLabel>

        <MuiSelect
         
        label={label}
        name = {name}
        value={value}
        onChange = {onChange}>
            {
                options.map( item=>(
                       <MenuItem key={item.id} value={item.id }>{item.title}</MenuItem> 
                    )
                )
            }
        </MuiSelect>
         {error && <FormHelperText>{error}</FormHelperText> }   
    </FormControl>
    
  )
}
