import React, { useEffect } from 'react';
import {connect} from "react-redux";
import * as actions from "../actions/employee";
import {Grid , Paper, Table,TableBody, TableCell, TableContainer, TableHead, TableRow} from "@material-ui/core"
import {EmployeeForm} from "./EmployeeForm"


const Employee = (props) => {
  useEffect(()=>{
    props.fetchallemployees()
    
  },[])
  return (
    <Paper>
      <Grid container>
        <Grid item xs={6}>
          <EmployeeForm/>
        </Grid>
        <Grid item xs={6}>
            <TableContainer>
                <Table>
                  <TableHead>
                    <TableRow>
                      <TableCell>Name</TableCell>
                      <TableCell>Skills</TableCell>
                      <TableCell>Age</TableCell>
                      <TableCell>Designation</TableCell>
                      <TableCell>Address</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {
                      console.log(props.employeelist)
                      // props.employeelist.map((employee,index)=>{
                        
                      //   return(
                      //     <TableRow key={index}>
                      //       <TableCell>{employee.Name}</TableCell>
                      //       <TableCell>{employee.Skills}</TableCell>
                      //       <TableCell>{employee.Age}</TableCell>
                      //       <TableCell>{employee.Designation}</TableCell>
                      //       <TableCell>{employee.Address}</TableCell>
                      //     </TableRow>
                      //   )
                      // })
                    }
                  </TableBody>
                </Table>
            </TableContainer>
        </Grid>
      </Grid>
    </Paper>
  )
}



const mapActionToProps = () =>{
  return{
    fetchallemployees : actions.fetchAllEmployees()
  }
}
const mapStateToProps = state =>{
  return{
    employeelist : state.employee.list,
 
  }
  
}

export default connect(mapStateToProps,mapActionToProps)(Employee);
