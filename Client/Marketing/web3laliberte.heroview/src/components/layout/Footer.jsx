import { MdAdminPanelSettings } from "react-icons/md";
import "./CSS/Footer.css";

function Footer() {
    const currentYear = new Date().getFullYear();
    const adminPortalURL = process.env.REACT_APP_ADMIN_URL;
    return (
        <footer className="px-4">
            <div className="foot-left d-flex">
                <p>Copyright &copy; {currentYear}, Web3 Laliberté. All Rights Reserved.</p>
            </div>
            <div className="foot-right d-flex">
                <a href={adminPortalURL}  rel="noopener noreferrer">
                    <MdAdminPanelSettings className="foot-icon" />
                    &nbsp;&nbsp;Admin Portal
                </a>
            </div>
        </footer>
    );
}

export default Footer;