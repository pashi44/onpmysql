// import { legacy_createStore } from "redux";//  deperected and migrated to  configureStore



import React, { act } from 'react';
import  {configureStore}  from '@reduxjs/toolkit'
const myobj =  {


    Name : "prashanth",
    Age :  '',
    Description : "thisis object  from redux store"
} 



const  myreducerFucntion =  ( initialstate  = myobj, action)=> 
{
switch(action.type){
    


    default: 
    return   initialstate;

}
}





const  store =  configureStore(
    
  {  reducer  : myreducerFucntion


  }

);

export default  store;