import React from "react";
import { Container } from "react-bootstrap";
import { Helmet, HelmetProvider } from "react-helmet-async";
import { AiOutlineFrown } from "react-icons/ai";
import "./CSS/NotFound.css";

const NotFound = () => {
    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>404 Not Found | Admin Portal</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="notfound-wrapper">
                <div className="notfound-content animate__animated animate__fadeIn">
                    <AiOutlineFrown className="notfound-icon" />
                    <h1>404</h1>
                    <p>Page Not Found</p>
                    <p>The page you are looking for does not exist.</p>
                </div>
            </Container>
        </>
    );
};

export default NotFound;