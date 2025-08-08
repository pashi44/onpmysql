// import { legacy_createStore } from "redux";//  deperected and migrated to  configureStore



import React, { act } from 'react';
import  {configureStore}  from '@reduxjs/toolkit'
const myobj =  {


    Name : "prashanth",
    Age :  '',
    Description : "thisis object  from redux store"
} 

//limitataions of the the reducer functinis it should be synchronus funation and do not mutate the 
// original state , rather  copy  a reference and append to re-render mouniting
const  myreducerFucntion =  ( initialstate  =  myobj, action)=> 
{
switch(action.type){
case  "Get_state":
  return  {...initialstate ,Name : action.payload}


    default: 
    return   {...initialstate};

}
}

const  store =  configureStore(
 {  reducer  : myreducerFucntion

  }

);

export default  store;