import React, { useEffect } from "react";
import { Container, Row, Col, Card } from "react-bootstrap";
import { Helmet, HelmetProvider } from "react-helmet-async";
import { Link } from "react-router-dom";
import { AiOutlineMail, AiOutlineShoppingCart, AiOutlineCreditCard, AiOutlineFileText } from "react-icons/ai";
import "./CSS/AdminDashboard.css";
import Shield from "./../assets/Routes/Shield";

const AdminDashboard = () => {
    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Admin Dashboard | Admin Portal</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="dashboard-wrapper">
                <Row>
                    <Col md={6}>
                        <Card className="dashboard-card">
                            <Card.Body>
                                <Card.Title><AiOutlineMail /> Inbox</Card.Title>
                                <Card.Text>
                                    View and manage your messages.
                                </Card.Text>
                                <Link to="/inbox" className="btn btn-primary">Go to Inbox</Link>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={6}>
                        <Card className="dashboard-card">
                            <Card.Body>
                                <Card.Title><AiOutlineShoppingCart /> Orders</Card.Title>
                                <Card.Text>
                                    View and manage customer orders.
                                </Card.Text>
                                <Link to="/orders" className="btn btn-primary">Go to Orders</Link>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
                <Row>
                    <Col md={6}>
                        <Card className="dashboard-card">
                            <Card.Body>
                                <Card.Title><AiOutlineCreditCard /> Transaction History</Card.Title>
                                <Card.Text>
                                    View transaction history.
                                </Card.Text>
                                <Link to="/transaction-history" className="btn btn-primary">Go to Transaction History</Link>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={6}>
                        <Card className="dashboard-card">
                            <Card.Body>
                                <Card.Title><AiOutlineFileText /> Content Management</Card.Title>
                                <Card.Text>
                                    Manage website content.
                                </Card.Text>
                                <Link to="/content-management" className="btn btn-primary">Go to Content Management</Link>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
            </Container>
        </>
    );
};

export default Shield(AdminDashboard);