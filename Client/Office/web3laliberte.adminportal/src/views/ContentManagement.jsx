import React, { useState, useEffect } from "react";
import { Container, Table, Button, Modal, Form } from "react-bootstrap";
import { Helmet, HelmetProvider } from "react-helmet-async";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { FaEdit, FaTrashAlt } from "react-icons/fa";
import "./CSS/ContentManagement.css";
import Shield from "../assets/Routes/Shield";

const ContentManagement = () => {
    const [faqs, setFaqs] = useState([]);
    const [selectedFaq, setSelectedFaq] = useState(null);
    const [showFaqModal, setShowFaqModal] = useState(false);
    const [faqForm, setFaqForm] = useState({ question: "", answer: "" });
    const BASE_API_URL = process.env.REACT_APP_API_URL;
    const FAQ_API_URL = `${BASE_API_URL}/faq`;

    useEffect(() => {
        fetchFaqs().then(r => console.log("FAQs fetched successfully!"));
    }, []);

    const fetchFaqs = async () => {
        try {
            const response = await axios.get(FAQ_API_URL);
            setFaqs(response.data);
        } catch (error) {
            console.error("Error fetching FAQs:", error);
        }
    };

    const handleFaqChange = (e) => {
        const { name, value } = e.target;
        setFaqForm({ ...faqForm, [name]: value });
    };

    const handleSaveFaq = async () => {
        try {
            if (selectedFaq) {
                await axios.put(`${FAQ_API_URL}/${selectedFaq.id}`, faqForm);
            } else {
                await axios.post(`${FAQ_API_URL}`, faqForm);
            }
            await fetchFaqs();
            setShowFaqModal(false);
            toast.success("FAQ saved successfully!");
        } catch (error) {
            console.error("Error saving FAQ:", error);
        }
    };

    const handleDeleteFaq = async (faqId) => {
        try {
            await axios.delete(`${FAQ_API_URL}/${faqId}`);
            await fetchFaqs();
            toast.success("FAQ deleted successfully!");
        } catch (error) {
            console.error("Error deleting FAQ:", error);
        }
    };

    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Content Management | Admin Portal</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="content-management-wrapper">
                <div className="faqs-wrapper">
                    <div className="d-flex justify-content-between align-items-center mb-3">
                        <h3>Manage Frequently Asked Questions</h3>
                        <Button onClick={() => { setSelectedFaq(null); setFaqForm({ question: "", answer: "" }); setShowFaqModal(true); }}>Add FAQ</Button>
                    </div>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>Question</th>
                                <th>Answer</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {faqs.map((faq, index) => (
                                <tr key={index}>
                                    <td>{faq.question}</td>
                                    <td>{faq.answer}</td>
                                    <td>
                                        <Button variant="warning" onClick={() => { setSelectedFaq(faq); setFaqForm(faq); setShowFaqModal(true); }}><FaEdit /></Button>
                                        <Button variant="danger" onClick={() => handleDeleteFaq(faq.id)} className="ml-2"><FaTrashAlt /></Button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </div>
                <Modal show={showFaqModal} onHide={() => setShowFaqModal(false)}>
                    <Modal.Header closeButton>
                        <Modal.Title>{selectedFaq ? "Edit FAQ" : "Add FAQ"}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form>
                            <Form.Group controlId="question">
                                <Form.Label>Question</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="question"
                                    value={faqForm.question}
                                    onChange={handleFaqChange}
                                />
                            </Form.Group>
                            <Form.Group controlId="answer">
                                <Form.Label>Answer</Form.Label>
                                <Form.Control
                                    as="textarea"
                                    rows={3}
                                    name="answer"
                                    value={faqForm.answer}
                                    onChange={handleFaqChange}
                                />
                            </Form.Group>
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={() => setShowFaqModal(false)}>Close</Button>
                        <Button variant="primary" onClick={handleSaveFaq}>Save</Button>
                    </Modal.Footer>
                </Modal>
                <ToastContainer />
            </Container>
        </>
    );
};

export default Shield(ContentManagement);