import React from "react";
import Header from "../header/Header";
import SideBar from "../sidebar/SideBar";


const PrivateLayout = ({children}) => {

    return (
        <div className="sb-nav-fixed">
            
            <Header />

            <div id="layoutSidenav">
                <div id="layoutSidenav_nav">
                    <SideBar/>
                </div>
                <div id="layoutSidenav_content">
                    <main>
                        {children}
                    </main>
                </div>
            </div>
        </div>
    )
}

export default PrivateLayout;
