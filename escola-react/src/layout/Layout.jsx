import { RenderComponent } from "simple-react-routing";
import Navbar from "./Navbar";

var fragment = <></>;

function Layout() {
    return (<>
        <Navbar></Navbar>
        <RenderComponent></RenderComponent>
    </>)
}

export default Layout;