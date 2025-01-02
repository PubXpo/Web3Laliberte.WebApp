import React, { useState, useEffect } from "react";
import { AiOutlineCreditCard } from "react-icons/ai";
import { Container, ListGroup, Row, Col, Card } from "react-bootstrap";
import { Helmet, HelmetProvider } from "react-helmet-async";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import "./CSS/TransactionHistory.css";
import Shield from "../assets/Routes/Shield";

const TransactionHistory = () => {
    const [transactions, setTransactions] = useState([]);
    const [selectedTransaction, setSelectedTransaction] = useState(null);
    const BASE_API_URL = process.env.REACT_APP_API_URL;
    const TRANSACTION_API_URL = `${BASE_API_URL}/api/transaction`;

    useEffect(() => {
        const fetchTransactions = async () => {
            try {
                const response = await fetch(TRANSACTION_API_URL);
                const allTransactions = await response.json();
                const nonPendingTransactions = allTransactions.filter(transaction => transaction.status !== "Pending");
                nonPendingTransactions.sort((a, b) => new Date(b.date) - new Date(a.date));
                setTransactions(nonPendingTransactions);
            } catch (error) {
                console.error("Error fetching transactions:", error);
            }
        };

        fetchTransactions();

        const ws = new WebSocket("ws://localhost:4000");

        ws.onmessage = (event) => {
            const newTransaction = JSON.parse(event.data);
            if (newTransaction.status !== "Pending") {
                setTransactions((prevTransactions) => {
                    const updatedTransactions = [newTransaction, ...prevTransactions];
                    updatedTransactions.sort((a, b) => new Date(b.date) - new Date(a.date));
                    return updatedTransactions;
                });
                toast.info("New transaction received!", {
                    position: "top-center",
                    autoClose: 3000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                });
            }
        };

        return () => ws.close();
    }, []);

    const handleSelectTransaction = (transaction) => {
        setSelectedTransaction(transaction);
    };

    const formatUIId = (transaction) => {
        const { bandId, transactionId } = transaction;
        return `OB${bandId}${transactionId.slice(0, 2)}${transactionId.slice(-4)}`;
    };

    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Transaction History | Admin Portal</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="transaction-history-wrapper">
                <Row>
                    <Col md={4} className="transactions-list-wrapper animate__animated animate__slideInLeft">
                        <h3>Transaction History</h3>
                        <ListGroup>
                            {transactions.map((transaction, index) => (
                                <ListGroup.Item
                                    key={index}
                                    action
                                    onClick={() => handleSelectTransaction(transaction)}
                                    active={selectedTransaction === transaction}
                                    className={selectedTransaction === transaction ? "active-item" : ""}
                                >
                                    <AiOutlineCreditCard /> {formatUIId(transaction)}
                                </ListGroup.Item>
                            ))}
                        </ListGroup>
                    </Col>
                    <Col md={8} className="transaction-details-wrapper animate__animated animate__slideInRight">
                       {selectedTransaction ? (
                            <Card className="transaction-details-card">
                                <Card.Header as="h5">Transaction Details</Card.Header>
                                <Card.Body>
                                    <Card.Title>Donation:</Card.Title>
                                    <Card.Text>
                                        <strong>Transaction ID:</strong> {formatUIId(selectedTransaction)}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Date:</strong> {new Date(selectedTransaction.date).toLocaleString()}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Amount:</strong> £{selectedTransaction.amount.toFixed(2)}
                                    </Card.Text>
                                    <hr />
                                    <Card.Title>Gifts:</Card.Title>
                                    <Card.Text>
                                        <strong>Band ID:</strong> {selectedTransaction.bandId}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Status:</strong> {selectedTransaction.status}
                                    </Card.Text>
                                    {selectedTransaction.gifts && selectedTransaction.gifts.length > 0 ? (
                                        <ul>
                                            {selectedTransaction.gifts.map((gift, index) => (
                                                <li key={index}>{gift.name}</li>
                                            ))}
                                        </ul>
                                    ) : (
                                        <p>No gifts included.</p>
                                    )}
                                    <hr />
                                    <Card.Title>Donor:</Card.Title>
                                    <Card.Text>
                                        <strong>Name:</strong> {selectedTransaction.title} {selectedTransaction.firstName} {selectedTransaction.surname}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Email:</strong> {selectedTransaction.email}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Address:</strong> {selectedTransaction.addressLine1}, {selectedTransaction.addressLine2}, {selectedTransaction.city}, {selectedTransaction.postcode}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Email Updates:</strong> {selectedTransaction.emailUpdates}
                                    </Card.Text>
                                </Card.Body>
                            </Card>
                        ) : (
                            <div className="no-transaction-selected">
                                <p>Select a transaction to view its details</p>
                            </div>
                        )}
                    </Col>
                </Row>
            </Container>
            <ToastContainer />
        </>
    );
};

export default Shield(TransactionHistory);