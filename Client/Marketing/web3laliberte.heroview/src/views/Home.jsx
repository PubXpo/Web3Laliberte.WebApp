import { Col, Container, Row } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import React from "react";
import { FaNetworkWired, FaUserShield, FaHandsHelping, FaLock } from "react-icons/fa";
import { Helmet, HelmetProvider } from "react-helmet-async";
import "./CSS/Home.css";

function Home() {
    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Welcome! | Web3 Laliberté</title>
                </Helmet>
            </HelmetProvider>
            <Container fluid className="home-wrapper">
                <div className="hero-section">
                    <Row className="hero-content animate__animated animate__fadeInLeft">
                        <Col md={6} className="hero-text">
                            <h2>Welcome to Web3 Laliberté</h2>
                            <p>
                                At Web3 Laliberté, we believe in a decentralized internet that prioritizes freedom. We advocate for privacy, security, and digital rights for all. Join us in making Web3 accessible and fair for everyone, and help us safeguard your digital freedom.
                            </p>
                            <p>
                                Our platform is designed to empower individuals and organizations to take control of their digital lives. We provide the tools and resources needed to navigate the complexities of the decentralized web, ensuring that everyone can benefit from the opportunities it offers.
                            </p>
                            <NavLink to="/donate" className="btn-connect text-center">
                                GET INVOLVED NOW
                            </NavLink>
                        </Col>
                        <Col md={6} className="image-content">
                            <FaNetworkWired size={150} />
                        </Col>
                    </Row>
                </div>
                <div className="mission-section">
                    <Row className="mission-content animate__animated animate__fadeInUp">
                        <Col md={6} className="image-content">
                            <FaUserShield size={150} />
                        </Col>
                        <Col md={6} className="text-content">
                            <h3>Our Mission</h3>
                            <p>
                                We are a nonprofit organization dedicated to advocating for privacy, freedom, and security in the decentralized world of Web3 technologies. As blockchain and digital currencies evolve, we focus on ensuring that users’ digital rights are safeguarded, fostering an open and equitable digital future.
                            </p>
                            <p>
                                Our mission is to create a world where technology serves the people, not the other way around. We work tirelessly to promote policies and practices that protect user privacy and security, and we develop innovative solutions that make the decentralized web more accessible and user-friendly.
                            </p>
                        </Col>
                    </Row>
                </div>
                <div className="impact-section">
                    <Row className="impact-content animate__animated animate__fadeInUp">
                        <Col md={6} className="text-content">
                            <h3>Our Impact</h3>
                            <ul>
                                <li>Successfully advocated for privacy laws that protect millions of users.</li>
                                <li>Developed open-source tools that enhance online security and privacy.</li>
                                <li>Educated thousands of individuals on safe digital practices through workshops and webinars.</li>
                            </ul>
                            <p>
                                Our impact is measured by the positive changes we bring to the digital landscape. We are proud of our achievements and remain committed to driving further progress in the field of digital rights and freedoms.
                            </p>
                        </Col>
                        <Col md={6} className="image-content">
                            <FaLock size={150} />
                        </Col>
                    </Row>
                </div>
                <div className="donate-section">
                    <Row className="donate-content animate__animated animate__fadeInUp">
                        <Col md={6} className="image-content">
                            <FaHandsHelping size={150} />
                        </Col>
                        <Col md={6} className="text-content">
                            <h3>Why Donate?</h3>
                            <p>Your donations help us continue our mission to protect digital rights and freedoms. With your support, we can:</p>
                            <ul>
                                <li>Expand our educational programs to reach more communities.</li>
                                <li>Develop new technologies that safeguard user privacy.</li>
                                <li>Advocate for stronger digital rights protections worldwide.</li>
                            </ul>
                            <p>
                                By donating to Web3 Laliberté, you are investing in a future where digital freedom is a reality for everyone. Your contributions enable us to continue our vital work and make a lasting impact on the world.
                            </p>
                            <NavLink to="/donate" className="btn-connect text-center">
                                DONATE NOW
                            </NavLink>
                        </Col>
                    </Row>
                </div>
            </Container>
        </>
    );
}

export default Home;