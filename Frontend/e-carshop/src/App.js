import "bootstrap/dist/css/bootstrap.css";
import './App.css';
import { BrowserRouter as Router,Switch,  Route } from 'react-router-dom';

//******** Layouts ********
import PrivateLayout from "./components/layouts/PrivateLayout";
//************************************************************ */


//******** Pages ********
import Sales from "./pages/admin/Sales"
//************************************************************ */

function App() {
  return (
    <div className="App">
      <Router>
            <Switch>
              <Route path={["/"]}>
              <PrivateLayout>
                <Switch>
                    <Route path='/'>
                      <Sales/>
                    </Route>
                  </Switch>
                </PrivateLayout>
                </Route>
            </Switch>
          </Router>
      </div>
  );
}

export default App;
