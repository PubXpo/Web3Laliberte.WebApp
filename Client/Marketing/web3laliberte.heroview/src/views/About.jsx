import { Helmet, HelmetProvider } from "react-helmet-async";
import { Container } from "react-bootstrap";
import "./CSS/About.css";

function About() {
    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>About | Web3 Laliberté</title>
                </Helmet>
            </HelmetProvider>

            <Container fluid className="about-wrapper">
                <div className="about-left animate__animated animate__zoomIn">
                    <h3>About Us</h3>
                    <h4>───&nbsp;&nbsp;Page <strong>02</strong></h4>
                </div>
                <div className="about-right animate__animated animate__fadeIn animate__slower py-3">
                    <p>
                        We are a nonprofit organisation dedicated to advocating for privacy, freedom, and security in the decentralised world of Web3 technologies. As blockchain and digital currencies evolve, we focus on ensuring that users’ digital rights are safeguarded, fostering an open and equitable digital future.
                    </p>
                    <p>
                        Our team works at the intersection of technology, policy, and advocacy to protect digital freedom. We promote privacy-enhancing technologies, support regulatory reforms that protect users, and educate communities on safe digital practices. We envision a world where decentralisation leads to greater transparency and personal autonomy.
                    </p>
                    <p>
                        Our core efforts include:
                    </p>
                    <ul>
                        <li>Promoting privacy-enhancing technologies that empower users.</li>
                        <li>Supporting regulatory reforms that protect digital rights.</li>
                        <li>Educating communities on safe and secure digital practices.</li>
                        <li>Advocating for policies that ensure an open and equitable digital future.</li>
                    </ul>
                    <p>
                        Join us in advocating for a Web3 ecosystem that prioritises rights, freedoms, and privacy for everyone. Together, we can create a decentralised internet that serves the people and protects their digital freedoms.
                    </p>
                </div>
            </Container>
        </>
    );
}

export default About;