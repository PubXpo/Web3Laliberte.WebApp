import React, {useEffect, useState,} from 'react';
import {Accordion, Container, FormControl, InputGroup, OverlayTrigger, Tooltip} from 'react-bootstrap';
import {Helmet, HelmetProvider} from "react-helmet-async";
import './CSS/FAQs.css';

function FAQs() {

    const [searchQuery, setSearchQuery] = useState("");
    const [activeFaq, setActiveFaq] = useState(null);
    const [faqs, setFaqs] = useState([]);
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        const fetchFaqs = async () => {
            try {
                const response = await fetch("http://localhost:4001/api/FAQ");
                const data = await response.json();
                setFaqs(data);
                setLoading(false);
            } catch (error) {
                console.error("Error fetching FAQs:", error);
                setLoading(false);
            }
        };

        fetchFaqs().then(r => console.log("FAQs fetched successfully!"));

        const interval = setInterval(fetchFaqs, 60000); // Update FAQs every 60 seconds
        return () => clearInterval(interval);
    }, []);

    // Filter FAQs based on the search query
    const filteredFaqs = searchQuery ? faqs.filter(faq =>
        faq.question.toLowerCase().includes(searchQuery.toLowerCase())
    ) : faqs.slice(0, 5);

    const handleToggle = (id) => {
        if (id === null) return;
        setActiveFaq(activeFaq === id ? null : id.toString());
    };


    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>FAQs | Web3 Laliberté</title>
                </Helmet>
            </HelmetProvider>
            <Container fluid className="faqs-wrapper">
                <div className="faqs-left animate__animated animate__zoomIn">
                    <h3>Frequently Asked Questions</h3>
                    <h4>───&nbsp;&nbsp;Page <strong>05</strong></h4>
                </div>

                {/* Search Bar */}
                <InputGroup className="faq-search-bar mb-4">
                    <InputGroup.Text>🔍</InputGroup.Text>
                    <FormControl
                        type="text"
                        placeholder="Search FAQs"
                        value={searchQuery}
                        onChange={(e) => setSearchQuery(e.target.value)}
                    />
                </InputGroup>

                <div className="faqs-right animate__animated animate__fadeIn animate__slower py-3">
                    <Accordion activeKey={activeFaq} onSelect={handleToggle} className="faq-accordion">
                        {filteredFaqs.length > 0 ? (
                            filteredFaqs.map((faq) => (
                                <Accordion.Item eventKey={faq.id.toString()} key={faq.id} className="faq-item">
                                    <Accordion.Header onClick={() => handleToggle(faq.id)}>
                                        <OverlayTrigger
                                            placement="top"
                                            overlay={<Tooltip>Click to view answer</Tooltip>}
                                        >
                                            <span className="faq-question">Q: {faq.question}</span>
                                        </OverlayTrigger>
                                    </Accordion.Header>
                                    <Accordion.Body className="faq-answer">
                                        A: {faq.answer}
                                    </Accordion.Body>
                                </Accordion.Item>
                            ))
                        ) : (
                            <div className="no-faqs-found">No FAQs found for your search query.</div>
                        )}
                    </Accordion>
                </div>
            </Container>
        </>
    );
}

export default FAQs;
