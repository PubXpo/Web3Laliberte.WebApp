import React, { useState, useEffect } from "react";
import { AiOutlineShoppingCart } from "react-icons/ai";
import { Button, Container, ListGroup, Row, Col, Modal, Form, Card, Spinner } from "react-bootstrap";
import { CSSTransition } from "react-transition-group";
import { Helmet, HelmetProvider } from "react-helmet-async";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import "./CSS/Orders.css";
import GiftCard from "../assets/Routes/GiftCard";
import Shield from "../assets/Routes/Shield";

const Orders = () => {
    const [orders, setOrders] = useState([]);
    const [gifts, setGifts] = useState([]);
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [showEditModal, setShowEditModal] = useState(false);
    const [editOrder, setEditOrder] = useState(null);
    const [showProcessingModal, setShowProcessingModal] = useState(false);
    const [processingMessage, setProcessingMessage] = useState("");
    const [newOrderCount, setNewOrderCount] = useState(0);
    const BASE_API_URL = process.env.REACT_APP_API_URL;
    const TRANSACTION_API_URL = `${BASE_API_URL}/api/transaction`;

    useEffect(() => {
        const fetchOrdersAndGifts = async () => {
            try {
                const response = await fetch(TRANSACTION_API_URL);
                const transactions = await response.json();
                const pendingOrders = transactions.filter(order => order.status === "Pending");
                pendingOrders.sort((a, b) => new Date(b.date) - new Date(a.date));
                setOrders(pendingOrders);

                // Extract gifts from transactions
                const stockMap = new Map();
                transactions.forEach(transaction => {
                    transaction.gifts.forEach(gift => {
                        if (!stockMap.has(gift.giftId)) {
                            stockMap.set(gift.giftId, gift);
                        }
                    });
                });
                setGifts(Array.from(stockMap.values()));
            } catch (error) {
                console.error("Error fetching orders and gifts:", error);
            }
        };

        fetchOrdersAndGifts();

        const ws = new WebSocket("ws://localhost:4000");

        ws.onmessage = (event) => {
            const newOrder = JSON.parse(event.data);
            setOrders((prevOrders) => {
                const updatedOrders = [newOrder, ...prevOrders];
                updatedOrders.sort((a, b) => new Date(b.date) - new Date(a.date));
                return updatedOrders;
            });
            toast.info("New order received!", {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
            setNewOrderCount((prevCount) => prevCount + 1);
        };

        return () => ws.close();
    }, []);

    const showProcessing = (message) => {
        setProcessingMessage(message);
        setShowProcessingModal(true);
        setTimeout(() => {
            setShowProcessingModal(false);
        }, 2000);
    };

    const handleSelectOrder = (order) => {
        setSelectedOrder(order);
        setNewOrderCount(0);
    };

    const handleEditOrder = (order) => {
        setEditOrder(order);
        setShowEditModal(true);
    };

    const handleFulfillOrder = async (orderId) => {
        try {
            showProcessing("Processing Fulfillment...");
            const updatedOrder = { ...selectedOrder, status: "Fulfilled" };
            await fetch(`${TRANSACTION_API_URL}/${orderId}/fulfill`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(updatedOrder),
            });

            setOrders((prevOrders) =>
                prevOrders.map((order) =>
                    order.transactionId === orderId ? updatedOrder : order
                )
            );

            if (selectedOrder && selectedOrder.transactionId === orderId) {
                setSelectedOrder(updatedOrder);
            }

            console.log(`Order ${orderId} fulfilled`);
        } catch (error) {
            console.error("Error fulfilling order:", error);
        }
    };

    const handleRejectOrder = async (orderId) => {
        try {
            showProcessing("Processing Rejection...");
            const updatedOrder = { ...selectedOrder, status: "Rejected" };
            await fetch(`${TRANSACTION_API_URL}/${orderId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(updatedOrder),
            });

            setOrders((prevOrders) =>
                prevOrders.map((order) =>
                    order.transactionId === orderId ? updatedOrder : order
                )
            );

            if (selectedOrder && selectedOrder.transactionId === orderId) {
                setSelectedOrder(updatedOrder);
            }

            console.log(`Order ${orderId} rejected`);
        } catch (error) {
            console.error("Error rejecting order:", error);
        }
    };

    const handleSaveEdit = async () => {
        try {
            await fetch(`${TRANSACTION_API_URL}/${editOrder.transactionId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(editOrder),
            });
            setShowEditModal(false);

            setOrders((prevOrders) =>
                prevOrders.map((order) =>
                    order.transactionId === editOrder.transactionId ? editOrder : order
                )
            );

            if (selectedOrder && selectedOrder.transactionId === editOrder.transactionId) {
                setSelectedOrder(editOrder);
            }

            console.log(`Order ${editOrder.transactionId} saved`);
        } catch (error) {
            console.error("Error saving order:", error);
        }
    };

    const handleUpdateGift = async (giftId, inventoryAmount) => {
        try {
            console.log(`Updating gift ${giftId} with inventory amount ${inventoryAmount}`);
            const response = await fetch(`${TRANSACTION_API_URL}/gift/${giftId}/inventory`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(inventoryAmount), 
            });
    
            if (!response.ok) {
                throw new Error("Failed to update gift inventory");
            }
    
            setGifts((prevGifts) =>
                prevGifts.map((gift) =>
                    gift.giftId === giftId ? { ...gift, inventoryAmount } : gift
                )
            );
            console.log(`Gift ${giftId} inventory updated`);
        } catch (error) {
            console.error("Error updating gift inventory:", error);
        }
    };

    const formatUIId = (order) => {
        const { bandId, transactionId } = order;
        return `OB${bandId}${transactionId.slice(0, 2)}${transactionId.slice(-4)}`;
    };

    const handleEditChange = (e) => {
        const { name, value } = e.target;
        setEditOrder((prevOrder) => ({
            ...prevOrder,
            [name]: value,
        }));
    };

    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Orders | Admin Portal</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="orders-wrapper">
                <Row>
                    <Col md={12} className="gifts-wrapper">
                        {gifts.length > 0 ? (
                            <div className="gifts-cards">
                                {gifts.map((gift, index) => (
                                    <GiftCard key={index} gift={gift} onUpdate={handleUpdateGift} />
                                ))}
                            </div>
                        ) : (
                            <p>No gifts available.</p>
                        )}
                    </Col>
                </Row>
                <Row>
                    <Col md={4} className="orders-list-wrapper animate__animated animate__slideInLeft">
                        <h3>Orders</h3>
                        <ListGroup>
                            {orders.map((order, index) => (
                                <ListGroup.Item
                                    key={index}
                                    action
                                    onClick={() => handleSelectOrder(order)}
                                    active={selectedOrder === order}
                                    className={selectedOrder === order ? "active-item" : ""}
                                >
                                    <AiOutlineShoppingCart /> {formatUIId(order)}
                                </ListGroup.Item>
                            ))}
                        </ListGroup>
                    </Col>
                    <Col md={8} className="order-details-wrapper animate__animated animate__slideInRight">
                        {selectedOrder ? (
                            <Card className="order-details-card">
                                <Card.Header as="h5">Order Details</Card.Header>
                                <Card.Body>
                                    <Card.Title>Donation:</Card.Title>
                                    <Card.Text>
                                        <strong>Transaction ID:</strong> {formatUIId(selectedOrder)}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Date:</strong> {new Date(selectedOrder.date).toLocaleString()}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Amount:</strong> £{selectedOrder.amount.toFixed(2)}
                                    </Card.Text>
                                    <hr />
                                    <Card.Title>Gifts:</Card.Title>
                                    <Card.Text>
                                        <strong>Band ID:</strong> {selectedOrder.bandId}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Status:</strong> {selectedOrder.status}
                                    </Card.Text>
                                    {selectedOrder.gifts && selectedOrder.gifts.length > 0 ? (
                                        <ul>
                                            {selectedOrder.gifts.map((gift, index) => (
                                                <li key={index}>{gift.name}</li>
                                            ))}
                                        </ul>
                                    ) : (
                                        <p>No gifts included.</p>
                                    )}
                                    <hr />
                                    <Card.Title>Donor:</Card.Title>
                                    <Card.Text>
                                        <strong>Name:</strong>  {selectedOrder.title} {selectedOrder.firstName} {selectedOrder.surname}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Email:</strong> {selectedOrder.email}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Address:</strong> {selectedOrder.addressLine1}, {selectedOrder.addressLine2}, {selectedOrder.city}, {selectedOrder.postcode}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Email Updates:</strong> {selectedOrder.emailUpdates}
                                    </Card.Text>
                                    <hr />
                                    <Button variant="success" onClick={() => handleFulfillOrder(selectedOrder.transactionId)}>
                                        Fulfill
                                    </Button>
                                    <Button variant="warning" onClick={() => handleEditOrder(selectedOrder)}>
                                        Edit
                                    </Button>
                                    <Button variant="danger" onClick={() => handleRejectOrder(selectedOrder.transactionId)}>
                                        Reject
                                    </Button>
                                </Card.Body>
                            </Card>
                        ) : (
                            <div className="no-order-selected">
                                <p>Select an order to view its details</p>
                            </div>
                        )}
                    </Col>
                </Row>
                <Modal show={showEditModal} onHide={() => setShowEditModal(false)} size="lg" className="edit-order-modal">
                    <Modal.Header closeButton>
                        <Modal.Title>Edit Order</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        {editOrder && (
                            <Form>
                                <Row>
                                    <Col md={12}>
                                        <Form.Group controlId="transactionId">
                                            <Form.Label>Transaction ID</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="transactionId"
                                                value={editOrder.transactionId}
                                                onChange={handleEditChange}
                                                readOnly
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col md={6}>
                                        <Form.Group controlId="status">
                                            <Form.Label>Status</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="status"
                                                value={editOrder.status}
                                                onChange={handleEditChange}
                                                readOnly
                                            />
                                        </Form.Group>
                                    </Col>
                                    <Col md={6}>
                                        <Form.Group controlId="title">
                                            <Form.Label>Title</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="title"
                                                value={editOrder.title}
                                                onChange={handleEditChange}
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col md={6}>
                                        <Form.Group controlId="firstName">
                                            <Form.Label>First Name</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="firstName"
                                                value={editOrder.firstName}
                                                onChange={handleEditChange}
                                            />
                                        </Form.Group>
                                    </Col>
                                    <Col md={6}>
                                        <Form.Group controlId="surname">
                                            <Form.Label>Surname</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="surname"
                                                value={editOrder.surname}
                                                onChange={handleEditChange}
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col md={6}>
                                        <Form.Group controlId="email">
                                            <Form.Label>Email</Form.Label>
                                            <Form.Control
                                                type="email"
                                                name="email"
                                                value={editOrder.email}
                                                onChange={handleEditChange}
                                                readOnly
                                            />
                                        </Form.Group>
                                    </Col>
                                    <Col md={6}>
                                        <Form.Group controlId="emailUpdates">
                                            <Form.Label>Email Updates</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="emailUpdates"
                                                value={editOrder.emailUpdates}
                                                onChange={handleEditChange}
                                                readOnly
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col md={12}>
                                        <Form.Group controlId="addressLine1">
                                            <Form.Label>Address Line 1</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="addressLine1"
                                                value={editOrder.addressLine1}
                                                onChange={handleEditChange}
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col md={12}>
                                        <Form.Group controlId="addressLine2">
                                            <Form.Label>Address Line 2</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="addressLine2"
                                                value={editOrder.addressLine2}
                                                onChange={handleEditChange}
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col md={6}>
                                        <Form.Group controlId="city">
                                            <Form.Label>City</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="city"
                                                value={editOrder.city}
                                                onChange={handleEditChange}
                                            />
                                        </Form.Group>
                                    </Col>
                                    <Col md={6}>
                                        <Form.Group controlId="postcode">
                                            <Form.Label>Postcode</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="postcode"
                                                value={editOrder.postcode}
                                                onChange={handleEditChange}
                                            />
                                        </Form.Group>
                                    </Col>
                                </Row>
                            </Form>
                        )}
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={() => setShowEditModal(false)}>
                            Close
                        </Button>
                        <Button variant="primary" onClick={handleSaveEdit}>
                            Save Changes
                        </Button>
                    </Modal.Footer>
                </Modal>
                <CSSTransition
                    in={showProcessingModal}
                    timeout={300}
                    classNames="fade"
                    unmountOnExit
                >
                    <Modal show={showProcessingModal} onHide={() => setShowProcessingModal(false)} centered>
                        <Modal.Body className="text-center">
                            <Spinner animation="border" role="status">
                            </Spinner>
                            <p>{processingMessage}</p>
                        </Modal.Body>
                    </Modal>
                </CSSTransition>
            </Container>
            <ToastContainer />
        </>
    );
};

export default Shield(Orders);