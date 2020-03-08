import React from 'react';
import "react-loader-spinner/dist/loader/css/react-spinner-loader.css";
import LoaderSpinner from 'react-loader-spinner';
import './index.css';

export const Loader = () => {
    return (
        <div className="loader-outer">
            <LoaderSpinner 
                type="TailSpin" 
                color="#707070" 
                height={200}
                width={200} 
                className="loader-inner"/>
        </div>
    )
}