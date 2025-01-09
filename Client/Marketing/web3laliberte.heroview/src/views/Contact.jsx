import { AiOutlineSend } from "react-icons/ai";
import { useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { Helmet, HelmetProvider } from "react-helmet-async";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import "./CSS/Contact.css";

function Contact() {
    const [formData, setFormData] = useState({
        name: "",
        email: "",
        subject: "",
        message: ""
    });
    const wordLimit = 200;

    const API_URL = process.env.REACT_APP_API_URL;
    
    const [isSent, setIsSent] = useState(false);
    const [error, setError] = useState(null);

    const handleChange = (e) => {
        const { name, value } = e.target;
        const wordCount = value.trim().split(/\s+/).length;

        if (name === "message" && wordCount <= wordLimit) {
            setFormData({ ...formData, [name]: value });
        } else if (name !== "message") {
            setFormData({ ...formData, [name]: value });
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post(`${API_URL}/ContactLog`, formData);
            if (response.status === 200) {
                setIsSent(true);
                setError(null);
                toast.success("Message sent successfully!", {
                    position: "top-center",
                    autoClose: 3000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                });
            }
        } catch (err) {
            setError(err.response?.data?.error || "An error occurred. Please try again.");
            toast.error("Failed to send message. Please try again.", {
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

    const currentWordCount = formData.message.trim() === "" ? 0 : formData.message.trim().split(/\s+/).length;

    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Contact | Web3 Laliberté</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="contact-wrapper">
                <div className="contact-left animate__animated animate__zoomIn">
                    <h3>Contact</h3>
                    <h4>
                        ───&nbsp;&nbsp;Page <strong>04</strong>
                    </h4>
                </div>
                <div className="contact-right">
                    <div className="contact-container">
                        <div className="row">
                            <div className="col contact-col animate__animated animate__slideInRight">
                                <div className="email-wrapper">
                                    {/* Contact Form */}
                                    <Form onSubmit={handleSubmit}>
                                        <Form.Group controlId="name">
                                            <Form.Label>Name</Form.Label>
                                            <Form.Control
                                                type="text"
                                                name="name"
                                                value={formData.name}
                                                onChange={handleChange}
                                                placeholder="Enter your name"
                                                required
                                            />
                                        </Form.Group>
                                        <Form.Group controlId="email">
                                            <Form.Label>Email Address</Form.Label>
                                            <Form.Control
                                                type="email"
                                                name="email"
                                                value={formData.email}
                                                onChange={handleChange}
                                                placeholder="Enter your email"
                                                required
                                            />
                                        </Form.Group>
                                        <Form.Group controlId="subject">
                                            <Form.Label>Subject</Form.Label>
                                            <Form.Control
                                                as="select"
                                                name="subject"
                                                value={formData.subject}
                                                onChange={handleChange}
                                                required
                                            >
                                                <option value="">Select a subject</option>
                                                <option value="General Enquiries">General enquiries</option>
                                                <option value="My Donations">My donations</option>
                                                <option value="My Data">My data</option>
                                                <option value="Legal Information">Legal information and outreach</option>
                                                <option value="Speaker Request">Speaker request</option>
                                            </Form.Control>
                                        </Form.Group>
                                        <Form.Group controlId="message">
                                            <Form.Label>Message</Form.Label>
                                            <Form.Control
                                                as="textarea"
                                                rows={4}
                                                name="message"
                                                value={formData.message}
                                                onChange={handleChange}
                                                placeholder="Enter your message"
                                                required
                                            />
                                            <div className={`word-count ${currentWordCount > wordLimit ? 'word-count-exceeded' : ''}`}>
                                                {Math.min(currentWordCount, wordLimit)} / {wordLimit} words
                                            </div>
                                        </Form.Group>
                                        {error && <div className="error-message">{error}</div>}
                                        <Button className={"btn-submit"} type="submit" disabled={isSent}>
                                            {!isSent &&   <AiOutlineSend />} 
                                            {isSent ? '  Sent' : '  Submit'}
                                        </Button>
                                    </Form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </Container>

            <ToastContainer />
        </>
    );
}

export default Contact;