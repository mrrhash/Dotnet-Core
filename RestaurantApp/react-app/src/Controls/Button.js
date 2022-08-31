import React from 'react'
import { Button as MuiButton } from '@mui/material';

export default function Button(props) {

    const {children , color , variant , onClick , ...other} = props;
  return (
    <MuiButton
    style={{margin:"8px"}}
    variant = {variant || 'contained'}
    onClick={onClick}
    color={color}
    {...other}
    >
        {children}
    </MuiButton>
  )
}
