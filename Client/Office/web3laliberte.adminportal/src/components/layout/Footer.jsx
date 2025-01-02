import "./CSS/Footer.css";
import {FaHandsHelping} from "react-icons/fa";

function Footer() {
    const currentYear = new Date().getFullYear();
    const flagshipHomeURL = process.env.REACT_APP_HEROVIEW_URL
    return (
        <footer className="px-4">
            <div className="foot-left d-flex">
                <p>Copyright &copy; {currentYear}, Web3 Laliberté. All Rights Reserved.</p>
            </div>
            <div className="foot-right d-flex">
                <a href={flagshipHomeURL} rel="noopener noreferrer">
                    < FaHandsHelping className="foot-icon"/>   
                    &nbsp;&nbsp;   Flagship Home
                </a>
            </div>
        </footer>
    );
}

export default Footer;
