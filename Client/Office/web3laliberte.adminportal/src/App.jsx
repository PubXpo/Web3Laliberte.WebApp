import React from "react";
import {Route, Routes} from "react-router-dom";
import {useState} from "react";
import {Spinner} from "react-bootstrap";
import NavTop from "./components/layout/NavTop";
import NavBot from "./components/layout/NavBot";
import Footer from "./components/layout/Footer";
import AdminDashboard  from "./views/AdminDashboard";
import Inbox from "./views/Inbox";
import Orders from "./views/Orders";
import TransactionHistory from "./views/TransactionHistory";
import AdminLogin from "./views/AdminLogin";
import ContentManagement from "./views/ContentManagement";
import NotFound from "./views/NotFound";

import "./index";

function App() {
    const [preload, setPreload] = useState(true);

    setTimeout(function () {
        setPreload(false);
    }, 2000);

    if (preload) {
        return (
            <div className="preload">
                <h1>
                    <strong>Web3 Laliberté</strong>
                </h1>
                <p>─────</p>
                <Spinner animation="grow"/>
            </div>
        );
    }

    return (
        <>
            <NavTop/>
            <div className="d-flex">
                <Routes>
                    <Route path="/login" element={<AdminLogin/>}></Route>
                    <Route path="/admin" element={<AdminDashboard/>}></Route>
                    <Route path="/inbox" element={<Inbox/>}></Route>
                    <Route path="/content-management" element={<ContentManagement/>}></Route>
                    <Route path="/orders" element={<Orders/>}></Route>
                    <Route path="/transaction-history" element={<TransactionHistory/>}></Route>
                    <Route path="*" element={<NotFound/>}></Route>
                </Routes>
            </div>
            <Footer/>
            <NavBot/>
        </>
    );
}

export default App;
