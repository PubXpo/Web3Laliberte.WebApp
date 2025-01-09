import { Container, Nav, Navbar } from "react-bootstrap";
import { Link, NavLink, useLocation } from "react-router-dom";
import React, { useState } from "react";
import { GrClose } from "react-icons/gr";
import { FaAlignRight, FaHandsHelping } from "react-icons/fa";
import "./CSS/NavTop.css";
import { useNavigate } from "react-router-dom";

function NavTop() {
    const [toggleMenu, setToggleMenu] = useState(false);
    const navigate = useNavigate();
    const location = useLocation();

    function toggleOpen() {
        setToggleMenu(true);
    }

    function toggleClose() {
        setToggleMenu(false);
    }

    const handleLogout = () => {
        localStorage.removeItem('isAdminAuthenticated');
        navigate('/login');
    };

    const validPaths = ['/', '/admin', '/inbox', '/orders', '/transaction-history', '/content-management'];
    if (validPaths.indexOf(location.pathname) === -1) {
        return null;
    }

    if (toggleMenu) {
        return (
            <>
                <NavTop />
                <div className="menu">
                    <Container fluid className="menu-close">
                        <button className="toggle-menu ms-auto" onClick={toggleClose}>
                            <GrClose />
                        </button>
                        <div className="menu-list">
                            <NavLink to="/admin" onClick={toggleClose}>
                                Dashboard
                            </NavLink>
                            <NavLink to="/inbox" onClick={toggleClose}>
                                Inbox
                            </NavLink>
                            <NavLink to="/orders" onClick={toggleClose}>
                                Orders
                            </NavLink>
                            <NavLink to="/transaction-history" onClick={toggleClose}>
                                Transaction History
                            </NavLink>
                            <NavLink to="/content-management" onClick={toggleClose}>
                                Content Management
                            </NavLink>
                            <NavLink to="/login" onClick={() => { handleLogout(); toggleClose(); }}>
                                Logout
                            </NavLink>
                        </div>
                    </Container>
                </div>
            </>
        );
    }

    return (
        <Navbar className="navtop py-3" expand="lg">
            <Container fluid className="px-4">
                <Navbar.Brand className="navtop-brand">
                    <Link to="/admin">
                        <FaHandsHelping className="navtop-icon"/>
                        Web3 Laliberté
                    </Link>
                    <h6 style={{marginLeft: '8px'}}> (Admin)</h6>
                </Navbar.Brand>

                <button className="toggle-menu" onClick={toggleOpen}>
                    <FaAlignRight/>
                </button>
                <Nav className="navtop-list ms-auto">
                    <Nav.Link className="pe-3">
                        <NavLink to="/admin" className={({isActive}) => (isActive ? "active" : "")}>
                            Dashboard
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink to="/inbox" className={({isActive}) => (isActive ? "active" : "")}>
                            Inbox
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink to="/orders" className={({isActive}) => (isActive ? "active" : "")}>
                            Orders
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink to="/transaction-history" className={({isActive}) => (isActive ? "active" : "")}>
                            Transaction History
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink to="/content-management" className={({isActive}) => (isActive ? "active" : "")}>
                            Content Management
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink to="/login" onClick={handleLogout}
                                 className={({isActive}) => (isActive ? "active" : "")}>
                            Logout
                        </NavLink>
                    </Nav.Link>
                </Nav>
            </Container>
        </Navbar>
    );
}

export default NavTop;