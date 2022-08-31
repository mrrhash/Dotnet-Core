import React from 'react'
import {Paper , List , ListItemText , ListItem} from '@mui/material';

export default function OrderedFoodItems(props) {

  const {orderedFoodItems} = props;

  return (
    <>
     <List>
       {
         orderedFoodItems.map((item,index)=>(
           <Paper key={index}>
             <ListItem>
               <ListItemText primary={item.foodItemName}>

               </ListItemText>
             </ListItem>
           </Paper>
         )) 
       }
     </List>
    </>
  )
}
