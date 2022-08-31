import { useState } from "react";
import React  from 'react'

export default function useForm(getFreshModalObject) {

    const [values , setValues] = useState(getFreshModalObject());
    const [errors , setErrors] = useState({});

  const handleInputChange = e =>{
    const {name , value} = e.target;
    setValues({
      ...values,
      [name] : value
    })
  }

  const resetFromControls = () =>{
      setValues(getFreshModalObject);
      setErrors({});
  }
  return {
        values,
        setValues,
        errors,
        setErrors,
        resetFromControls,
        handleInputChange

    }
  
}
