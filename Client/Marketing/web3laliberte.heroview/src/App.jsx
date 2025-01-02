import {Route, Routes} from "react-router-dom";
import {useState} from "react";
import {Spinner} from "react-bootstrap";
import NavTop from "./components/layout/NavTop";
import NavBot from "./components/layout/NavBot";
import Footer from "./components/layout/Footer";
import Contact from "./views/Contact";
import About from "./views/About";
import Home from "./views/Home";
import FAQs from "./views/FAQs";
import Donate from "./views/Donate";
import NotFound from "./views/NotFound";
import "./index";

function App() {
    const [preload, setPreload] = useState(true);

    setTimeout(function () {
        setPreload(false);
    }, 2000);

    if (preload) {
        return (
            <div className="preload">
                <h1>
                    <strong>Web3 Laliberté</strong>
                </h1>
                <p>─────</p>
                <Spinner animation="grow"/>
            </div>
        );
    }

    return (
        <>
            <NavTop/>
            <div className="d-flex">
                <Routes>
                    <Route path="/" element={<Home/>}></Route>
                    <Route path="/about" element={<About/>}></Route>
                    <Route path="/contact" element={<Contact/>}></Route>
                    <Route path="/faqs" element={<FAQs/>}></Route>
                    <Route path="/donate" element={<Donate/>}></Route>
                    <Route path="*" element={<NotFound/>}></Route>
                </Routes>
            </div>
            <Footer/>
            <NavBot/>
        </>
    );
}

export default App;
