
import './App.css';
import {store} from "./actions/store";
import { Provider } from "react-redux";
import Employee from './components/Employee';
import {Container} from "@material-ui/core"
 
function App() {
  return (
    <Provider store={store}>
      <Container maxWidth="md">
      <Employee/>
      </Container>
    </Provider>
  );  
}

export default App;
