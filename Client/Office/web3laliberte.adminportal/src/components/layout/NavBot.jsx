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
            titlePage = "Dashboard";
            break;
        case  "/admin":
            numberPage = "01";
            titlePage = "Dashboard";
            break;
        case "/inbox":
            numberPage = "02";
            titlePage = "Inbox";
            break;
        case "/orders":
            numberPage = "03";
            titlePage = "Orders";
            break;
        case "/transaction-history":
            numberPage = "04";
            titlePage = "Transaction History";
            break;
        case "/content-management":
            numberPage = "05";
            titlePage = "Content Management";
            break;
        default:
    }

    // Direct Up
    switch (pathname) {
        case "/":
            directUp = "/content-management";
            break;
        case "/admin":
            directUp = "/content-management";
            break;
        case "/inbox":
            directUp = "/admin";
            break;
        case "/orders":
            directUp = "/inbox";
            break;
        case "/transaction-history":
            directUp = "/orders";
            break;
        case "/content-management":
            directUp = "/transaction-history";
            break;
        default:
    }

    // Direct Down
    switch (pathname) {
        case "/":
            directDown = "/inbox";
            break;
        case "/admin":
            directDown = "/inbox";
            break;
        case "/inbox":
            directDown = "/orders";
            break;
        case "/orders":
            directDown = "/transaction-history";
            break;
        case "/transaction-history":
            directDown = "/content-management";
            break;
        case "/content-management":
            directDown = "/";
            break;
        default:
    }
    const validPaths = ['/', '/admin', '/inbox', '/orders', '/transaction-history', '/content-management'];
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
