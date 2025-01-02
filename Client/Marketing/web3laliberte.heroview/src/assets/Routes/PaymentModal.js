import React, {useState} from 'react';
import {Button, Modal, Spinner} from 'react-bootstrap';
import {AiOutlineCheckCircle} from 'react-icons/ai';

const PaymentModal = ({show, handleClose, handlePayment}) => {
    const [loading, setLoading] = useState(true);
    const [success, setSuccess] = useState(false);

    const mockPayment = () => {
        setLoading(true);
        setSuccess(false);
        setTimeout(() => {
            setLoading(false);
            setSuccess(true);
        }, 2000); // Simulate a 2-second payment process
    };

    React.useEffect(() => {
        if (show) {
            mockPayment();
        }
    }, [show]);

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Modal.Body className="text-center">
                {loading && <Spinner animation="border"/>}
                {success && (
                    <div>
                        <AiOutlineCheckCircle size={50} color="green"/>
                        <h4>Payment Successful!</h4>
                    </div>
                )}
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default PaymentModal;