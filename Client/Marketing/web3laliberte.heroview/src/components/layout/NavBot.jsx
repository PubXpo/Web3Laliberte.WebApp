import {Link, useLocation} from "react-router-dom";
import {AiOutlineArrowLeft, AiOutlineArrowRight} from "react-icons/ai";
import "./CSS/NavBot.css";

function NavBot() {
    let numberPage;
    let titlePage;
    let directUp;
    let directDown;
    const {pathname} = useLocation();

    switch (pathname) {
        case "/":
            numberPage = "01";
            titlePage = "Home";
            break;
        case "/about":
            numberPage = "02";
            titlePage = "About";
            break;
        case "/donate":
            numberPage = "03";
            titlePage = "Donate";
            break;
        case "/contact":
            numberPage = "04";
            titlePage = "Contact";
            break;
        case "/faqs":
            numberPage = "05";
            titlePage = "FAQs";
            break;
        default:
    }

    // Direct Up
    switch (pathname) {
        case "/":
            directUp = "/faqs";
            break;
        case "/about":
            directUp = "/";
            break;  
        case "/donate":
            directUp = "/about";
            break; 
        case "/contact":
            directUp = "/donate";
            break;
        case "/faqs":
            directUp = "/contact";
            break;
        default:
    }

    // Direct Down
    switch (pathname) {
        case "/":
            directDown = "/about";
            break;
        case "/about":
            directDown = "/donate";
            break;
        case "/donate":
            directDown = "/contact";
            break;
        case "/contact":
            directDown = "/faqs";
            break;
        case "/faqs":
            directDown = "/";
            break;
            
        default:
    }
    
    const validPaths = ["/", "/about", "/donate", "/contact", "/faqs"];
    if (validPaths.indexOf(pathname) === -1) {
        return null;
    }
    
    return (

        <footer className="navbot px-4">
            <div className="navbot-left d-flex">
                <p className="navbot-title">{titlePage}</p>
                <p className="navbot-number">
                    {numberPage} <span className="disabled-color">/ 05</span>
                </p>
            </div>
            <div className="navbot-right d-flex">
                <Link to={directUp} className="d-flex align-items-center arrow">
                    <AiOutlineArrowLeft/>
                </Link>
                <Link
                    to={directDown}
                    className="d-flex align-items-center ps-4 arrow"
                >
                    <AiOutlineArrowRight/>
                </Link>
            </div>
        </footer>
    );
}

export default NavBot;
