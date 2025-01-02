import { Container, Nav, Navbar } from "react-bootstrap";
import {Link, NavLink, useLocation} from "react-router-dom";
import { useState } from "react";
import { GrClose } from "react-icons/gr";
import { FaAlignRight, FaHandsHelping } from "react-icons/fa"; 
import "./CSS/NavTop.css";

function NavTop() {
    const [toggleMenu, setToggleMenu] = useState(false);
    const location = useLocation();


    function toggleOpen() {
        setToggleMenu(true);
    }

    function toggleClose() {
        setToggleMenu(false);
    }

    if (toggleMenu) {
        return (
            <>
                <NavTop/>
                <div className="menu">
                    <Container fluid className="menu-close">
                        <button className="toggle-menu ms-auto" onClick={toggleClose}>
                            <GrClose/>
                        </button>
                        <div className="menu-list">
                            <NavLink to="/" onClick={toggleClose}>
                                Home
                            </NavLink>
                            <NavLink to="/about" onClick={toggleClose}>
                                About
                            </NavLink>
                            <NavLink to="/donate" onClick={toggleClose}>
                                GET INVOLVED
                            </NavLink>
                            <NavLink to="/contact" onClick={toggleClose}>
                                Contact
                            </NavLink>
                            <NavLink to="/faqs" onClick={toggleClose}>
                                FAQs
                            </NavLink>
                        </div>
                    </Container>
                </div>
            </>
        );
    }
    const validPaths = ['/', '/about', '/donate', '/contact', '/faqs'];
    if (validPaths.indexOf(location.pathname) === -1) {
        return null;
    }

    return (
        <Navbar className="navtop py-3" expand="lg">
            <Container fluid className="px-4">
                <Navbar.Brand className="navtop-brand">         
                    <Link to="/">
                        <FaHandsHelping className="navtop-icon" />
                        Web3 Laliberté
                    </Link>
                </Navbar.Brand>
                <button className="toggle-menu" onClick={toggleOpen}>
                    <FaAlignRight/>
                </button>
                <Nav className="navtop-list ms-auto">
                    <Nav.Link className="pe-3">
                        <NavLink
                            to="/"
                            className={({isActive}) => (isActive ? "active" : "")}
                        >
                            Home
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink
                            to="/about"
                            className={({isActive}) => (isActive ? "active" : "")}
                        >
                            About
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink
                            to="/donate"
                            className={({isActive}) => (isActive ? "active" : "")}
                        >
                            GET INVOLVED
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink
                            to="/contact"
                            className={({isActive}) => (isActive ? "active" : "")}
                        >
                            Contact
                        </NavLink>
                    </Nav.Link>
                    <Nav.Link className="pe-3">
                        <NavLink
                            to="/faqs"
                            className={({isActive}) => (isActive ? "active" : "")}
                        >
                            FAQs
                        </NavLink>
                    </Nav.Link>
                </Nav>
            </Container>
        </Navbar>
    );
}

export default NavTop;
