
import Form from '../../Layouts/Form'
import { Button as MuiButton, ButtonGroup, Grid , InputAdornment} from '@mui/material'
import Input from '../../Controls/Input'
import Select from '../../Controls/Select'
import Button from '../../Controls/Button'  
import RestaurantIcon from '@mui/icons-material/Restaurant';
import ReplayIcon from '@mui/icons-material/Replay';
import Reorder from '@mui/icons-material/Reorder'
import { createAPIEndPoint , EndPoints } from '../../api'
import { useEffect, useState } from 'react'

const pMethods = [
  {id : 'none' , title : 'Select'},
  {id : 'Cash' , title : 'Cash'},
  {id : 'Card' , title : 'Card'}
]



export default function OrderForm(props) {

  const { values , errors , handleInputChange } = props;
  const [customerList , setCustomerList] = useState([])

  useEffect(()=>{
     createAPIEndPoint(EndPoints.CUSTOMER).fetchAll()
     .then(res =>{
       let customerList = res.data.map(item => ({
         id : item.customerID,
         title : item.customerName
       }))
       customerList = [{id : 0 , title : 'Select'}].concat(customerList);
       setCustomerList(customerList);
     })
     .catch(err => console.log(err))
  },[])

  return (
      <Form>
        <Grid container >
          <Grid item xs={6}>
            <Input
            disabled
            label="Order Number"
            name = "orderNumber"
            value = {values.orderNumber}
            InputProps={{
              startAdornment:
                <InputAdornment style={{color:"yellow",fontWeight:"bolder",fontSize:"1.5em"}} position="start">#</InputAdornment>              
            }}
            />
            <Select
            label="Customer"
            name = "customerId"
            value = {values.customerId}
            onChange = {handleInputChange}
            options ={customerList}
            
            />
          </Grid>
          <Grid item xs={6}>
          <Select
            label="Payment Method"
            name = "pMethod"
            options = {pMethods}
            value = {values.pMethod}
            onChange = {handleInputChange}
            />
          <Input
            disabled  
            label="Grand Total"
            name = "gTotal "
            value = {values.gTotal}
            InputProps={{
              startAdornment:
                <InputAdornment position="start">$</InputAdornment>              
            }}
            />
            <ButtonGroup style={{margin: '8px'}}>
              <MuiButton
              type='submit'
              size='large'
              style={{backgroundColor: 'purple' , color: 'white' , borderColor: 'black'}}
              endIcon={<RestaurantIcon/>}>
              Submit
              </MuiButton>
              <MuiButton
              size='small'
              style={{backgroundColor: 'purple' , color: 'white' , borderColor: 'black'}}
              startIcon={<ReplayIcon/>}
              />
            </ButtonGroup>
            <Button
              size="large"
              startIcon={<Reorder/>}
              >
                Orders
              </Button>
          </Grid>
        </Grid>
      </Form>
  )
}
