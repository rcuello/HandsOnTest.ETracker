import React from 'react';

function Header(){
    return (
        <nav className="sb-topnav navbar navbar-expand navbar-dark bg-dark">
    
            <a className="navbar-brand ps-3" href="index.html">E-CarShop</a>
            
            <button className="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" href="#!"><i className="fas fa-bars"></i></button>
            
            <form className="d-none d-md-inline-block form-inline ms-auto me-0 me-md-3 my-2 my-md-0">
                <div className="input-group" >
                   
                </div>
            </form>
            
            
        </nav>
    )
}

export default Header;