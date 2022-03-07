import React, {useEffect,useState} from "react";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { NavLink,Link } from 'react-router-dom';
import { uploadFile } from '../../utils/api';
import {nanoid} from "nanoid";

//For debugging
//import data from "./../../mock-data.json";

const Sales = () => {
    const [selectedFile, setSelectedFile] = useState();
    const [sales, setSales] = useState([]);

    // On file upload (click the upload button) 
    const onFileUpload = async () => {
        const formData = new FormData();

		formData.append('File', selectedFile);
        
        await uploadFile(formData,
            (response)=>{
                setSales(response.data);
                toast.success('Success');
                

            },(error)=>{
               
                toast.error('Error'+error);

                if (error.response) {
                    console.error(error.response.data);
                    console.error(error.response.status);
                    console.error(error.response.headers);
                    
                  }
            });

    }
    

    // On file select (from the pop up) 
    const onFileChange = event => { 
        // Update the state 
        setSelectedFile(event.target.files[0]);
      }; 

    return (
        <div className="container-fluid px-4">
            <ToastContainer position='bottom-center' autoClose={5000} />
            <h1 className="mt-4">Sales</h1>
            
            <div className="card mb-4">
                <div className="card-header">
                    <div className="d-flex justify-content-between">
                        <div>
                            <i className="fas fa-table me-1"></i>
                            Upload sales
                        </div>
                        <NavLink className="link-dark" to="/admin/product/new">
                            <i className="far fa-plus-square"></i>
                        </NavLink>
                    </div>
                </div>
                <div className="card-body">
                    <input type="file" onChange={onFileChange} />
                    <button onClick={onFileUpload}> 
                        Upload! 
                    </button> 

                    <table id="dtDataSet" className="table table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>DealNumber</th>
                                <th>CustomerName</th>
                                <th>DealershipName</th>
                                <th>Vehicle</th>
                                <th>Price</th>
                                <th>Date</th>
                            </tr>
                        </thead>
                        
                        {
                            (Array.isArray(sales) && sales.length) ?
                            
                                <TableCarSales sales={sales}/>
                            :
                                <EmptyTable />
                        }
                        
                        
                    </table>
                </div>
            </div>

        </div>
    )
}
const TableCarSales = ({sales})=>{
    return (
        <tbody>
                            
            {
                
            sales.map((sale)=>(
                <tr key={nanoid()}>
                    <td>{sale.dealNumber}</td>
                    <td>{sale.customerName}</td>
                    <td>{sale.dealershipName}</td>
                    <td>{sale.vehicle}</td>
                    <td>{sale.price}</td>
                    <td>{sale.date}</td>
                </tr>))
            }
            
        </tbody>
    );
};
const EmptyTable =()=>{
    return (
        <tbody>
            <tr>
                <td colSpan="6">No records to display</td>
            </tr>
        </tbody>
    );
}
export default Sales;