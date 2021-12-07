import { Link } from "react-router-dom";

const Navbar = () => {
    return (
      <nav
        style={{
          borderBottom: 'solid 1px',
          paddingBottom: '1rem',
        }}
      >
        <Link to="/">Login</Link>
        <Link to="/Recipes">Recipes</Link>
      </nav>
    );
  };

  export default Navbar;