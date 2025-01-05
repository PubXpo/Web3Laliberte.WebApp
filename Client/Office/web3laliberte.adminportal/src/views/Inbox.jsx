import { AiOutlineMail } from "react-icons/ai";
import { useState, useEffect } from "react";
import { Button, Container, ListGroup, Row, Col, Card, Modal, Form } from "react-bootstrap";
import { Helmet, HelmetProvider } from "react-helmet-async";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import "./CSS/Inbox.css";
import Shield from "../assets/Routes/Shield";

function Inbox() {
    const [messages, setMessages] = useState([]);
    const [selectedMessage, setSelectedMessage] = useState(null);
    const [showModal, setShowModal] = useState(false);
    const [replyContent, setReplyContent] = useState("\n\n\nThank you,\nFrom the Web3 Laliberté Team");
    const [newMessageCount, setNewMessageCount] = useState(0);
    const BASE_API_URL = process.env.REACT_APP_API_URL;
    const CONTACTLOG_API_URL = `${BASE_API_URL}/contactlog`;

    useEffect(() => {
        const fetchMessages = async () => {
            try {
                const response = await axios.get(CONTACTLOG_API_URL);
                const sortedMessages = response.data.sort((a, b) => new Date(b.createdAt) - new Date(a.createdAt));
                setMessages(sortedMessages);
            } catch (error) {
                console.error("Error fetching messages:", error);
            }
        }

        fetchMessages().then(r => console.log("Messages fetched successfully!"));
     
        const ws = new WebSocket('ws://localhost:4000/ws');
         // Add a WebSocket connection to the service to limit the number of requests made to the server

        ws.onmessage = (event) => {
            const newMessage = JSON.parse(event.data);
            setMessages((prevMessages) => {
                const updatedMessages = [newMessage, ...prevMessages];
                updatedMessages.sort((a, b) => new Date(b.createdAt) - new Date(a.createdAt));
                return updatedMessages;
            });
            toast.info("New message received!", {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
            setNewMessageCount((prevCount) => prevCount + 1);
        };

        return () => ws.close();
    }, []);

    useEffect(() => {
        if (newMessageCount > 0) {
            document.title = `(${newMessageCount}) New Messages - Admin Portal`;
        } else {
            document.title = "Inbox | Admin Portal";
        }
    }, [newMessageCount]);

    const handleSelectMessage = (message) => {
        setSelectedMessage(message);
        setNewMessageCount(0);
    };

    const handleDeleteMessage = async (messageId) => {
        try {
            await axios.delete(`${CONTACTLOG_API_URL}/${messageId}`);
            setMessages(messages.filter(msg => msg.id !== messageId));
            setSelectedMessage(null);
        } catch (error) {
            console.error("Error deleting message:", error);
        }
    };

    const handleSendReply = () => {
        toast.info("Sending...", {
            position: "top-center",
            autoClose: 1000,
            hideProgressBar: true,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
        });

        setTimeout(() => {
            setShowModal(false);
            toast.success("Message sent!", {
                position: "top-center",
                autoClose: 3000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
        }, 1000);
    };

    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Inbox | Admin Portal</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="inbox-wrapper">
                <Row>
                    <Col md={4} className="messages-wrapper animate__animated animate__slideInLeft">
                        <h3>Inbox</h3>
                        <ListGroup>
                            {messages.map((message, index) => (
                                <ListGroup.Item
                                    key={index}
                                    action
                                    onClick={() => handleSelectMessage(message)}
                                    active={selectedMessage === message}
                                    className={selectedMessage === message ? "active-item" : ""}
                                >
                                    <AiOutlineMail /> {message.subject}
                                </ListGroup.Item>
                            ))}
                        </ListGroup>
                    </Col>
                    <Col md={8} className="message-details-wrapper animate__animated animate__slideInRight">
                        {selectedMessage ? (
                            <Card className="message-details-card">
                                <Card.Header as="h5">{selectedMessage.subject}</Card.Header>
                                <Card.Body>
                                    <Card.Text>
                                        <strong>From:</strong> {selectedMessage.email}
                                    </Card.Text>
                                    <Card.Text>
                                        <strong>Sent At:</strong> {new Date(selectedMessage.createdAt).toLocaleString()}
                                    </Card.Text>
                                    <Card.Text className="message-content">
                                        {selectedMessage.message}
                                        <div className="signature">
                                            <br/><br/>
                                            Best regards<br/> <br/>
                                            
                                        </div>
                                    </Card.Text>
                                    <Button variant="success" onClick={() => setShowModal(true)}>
                                        Reply
                                    </Button>
                                    <Button variant="danger" onClick={() => handleDeleteMessage(selectedMessage.id)}>
                                        Delete
                                    </Button>
                                    <Button variant="primary" onClick={() => setSelectedMessage(null)}>
                                        Close
                                    </Button>
                                </Card.Body>
                            </Card>
                        ) : (
                            <div className="no-message-selected">
                                <p>Select a message to view its details</p>
                            </div>
                        )}
                    </Col>
                </Row>
            </Container>

            <Modal show={showModal} onHide={() => setShowModal(false)}>
                <Modal.Header closeButton>
                    <Modal.Title>Reply to Message</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group controlId="replyContent">
                            <Form.Label>Reply</Form.Label>
                            <Form.Control
                                as="textarea"
                                rows={5}
                                value={replyContent}
                                onChange={(e) => setReplyContent(e.target.value)}
                                className="reply-textarea"
                            />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={() => setShowModal(false)}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleSendReply}>
                        Send Reply
                    </Button>
                </Modal.Footer>
            </Modal>
            <ToastContainer />
        </>
    );
}

export default Shield(Inbox);