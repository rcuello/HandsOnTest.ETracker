import React from "react";
import { Link, NavLink } from 'react-router-dom';

const SideBar = ()=>{

    return <nav className="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
        <div className="sb-sidenav-menu">
            <div className="nav">
                <div className="sb-sidenav-menu-heading">Admin panel</div>
                
                <SideBarPage icono="fas fa-tachometer-alt"  nombre="Upload file" ruta="/"/>
                
            </div>
        </div>
        
        <div className="sb-sidenav-footer">
        @e-challenge
        </div>
    </nav>
}

const SideBarPage = ({icono,ruta,nombre})=>{
    return (
        <Link className="nav-link" to={ruta}>
            <div className="sb-nav-link-icon"><i className={icono}></i></div>
            {nombre}
        </Link>
    )
}

export default SideBar;