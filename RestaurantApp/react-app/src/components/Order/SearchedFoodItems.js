import {  IconButton, InputBase, List,ListItem, ListItemSecondaryAction, ListItemText, Paper } from '@mui/material';
import React, { useEffect, useState } from 'react'
import { createAPIEndPoint, EndPoints } from '../../api'
import SearchIcon from '@mui/icons-material/Search';
import PlusOneIcon from '@mui/icons-material/PlusOne';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import { styled } from '@mui/material/styles';

const CustomizedList = styled(List)(({theme})=>({

    marginTop:theme.spacing(1),
    maxHeight:250,
    overflow:'auto',

    '& li:hover':{
        cursor:'pointer',
        background : '#E3E3E3'
    },
    '& .MuiButtonBase-root':{
        display:'none'
    },
    '& li:hover .MuiButtonBase-root':{
        display:'block',
        color:'#000'
    },
}));
    // & li:hover{
    //     cursor:pointer;
    //     background: #E3E3E3        
    // };  
    // & .MuiButtonBase-root {
    //     display:none
    // };
    
    // & li:hover .MuiButtonBase-root{
    //     display:block;
    //     color:#000
    // }

    
    export default function SearchedFoodItems(props) {

    const {addFoodItem} = props;    

    const [searchItems , setSearchItems] = useState([]);
    const [searchKey , setSearchKey] = useState('');
    const [searchList , setSearchList] = useState([]);
   
   
    useEffect(()=>{
        createAPIEndPoint(EndPoints.FOODITEM).fetchAll()
        .then( res =>{
                setSearchItems(res.data);
                setSearchList(res.data);
        })
        .catch(err => console.log(err))
    },[]);

    useEffect(()=>{
        let x = [...searchItems];
        x = x.filter(y =>{
            return y.foodItemName.toLowerCase().includes(searchKey.toLocaleLowerCase())
        })
        setSearchList(x);
    },[searchKey])

  return (
      <>
     <Paper style={{padding:"2px 4px",display:"flex",alignitems:"center"}}>
       <InputBase
        style={{marginLeft:"8px",flex:"1"}} 
        placeholder='Search food items'
        value={searchKey}
        onChange={e => setSearchKey(e.target.value)}
        />
       <IconButton>
           <SearchIcon />
       </IconButton>
   </Paper>
     <CustomizedList>
         {
             searchList.map((item)=>(
                 <ListItem key={item.foodItemId} >
                     <ListItemText 
                     primary={item.foodItemName}
                     secondary={item.price}
                     />
                     <ListItemSecondaryAction>
                         <IconButton onClick={e => addFoodItem(item)}>
                            <PlusOneIcon/>
                            <ArrowForwardIosIcon/>
                         </IconButton>
                     </ListItemSecondaryAction>
                 </ListItem>
             ))
         }
     </CustomizedList>
     </> 
  )
}
