import React from 'react';
import ReactDOM from 'react-dom/client';
import  Make  from   "./UseStat" 
import Reduce from './UseRedu';
import Effec  from './UseEff';


const stateDiv = ReactDOM.createRoot(document.getElementById('states'));




stateDiv.render(

<React.Fragment>
    {/* < Make/> */}


{/* <Effec/>     */}

<Reduce />
</React.Fragment>





    

);


export default stateDiv;





