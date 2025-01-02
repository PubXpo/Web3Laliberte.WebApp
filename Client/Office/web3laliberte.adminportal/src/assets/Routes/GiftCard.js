import React, { useState } from "react";
import { Card, Button, Modal, Form } from "react-bootstrap";
import { FaEdit } from "react-icons/fa";

const GiftCard = ({ gift, onUpdate }) => {
    const [showModal, setShowModal] = useState(false);
    const [inventoryAmount, setInventoryAmount] = useState(gift.inventoryAmount);

    const handleEditClick = () => {
        setShowModal(true);
    };

    const handleSave = () => {
        onUpdate(gift.giftId, inventoryAmount);
        setShowModal(false);
    };

    return (
        <>
            <Card className="gift-card">
                <Card.Body>
                    <Button variant="link" className="edit-button" onClick={handleEditClick}>
                        <FaEdit />
                    </Button>
                    <Card.Title>{gift.name}</Card.Title>
                    <Card.Text>
                        <strong>Stock:</strong> {gift.inventoryAmount}
                    </Card.Text>
                </Card.Body>
            </Card>

            <Modal show={showModal} onHide={() => setShowModal(false)}>
                <Modal.Header closeButton>
                    <Modal.Title>Edit Inventory Amount</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group controlId="inventoryAmount">
                            <Form.Label>Gift</Form.Label>
                            <Form.Control
                                type="text"
                                value={gift.name}
                                disabled
                            />
                            <Form.Label>Inventory Amount</Form.Label>
                            <Form.Control
                                type="number"
                                value={inventoryAmount}
                                onChange={(e) => setInventoryAmount(e.target.value)}
                            />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={() => setShowModal(false)}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleSave}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};

export default GiftCard;