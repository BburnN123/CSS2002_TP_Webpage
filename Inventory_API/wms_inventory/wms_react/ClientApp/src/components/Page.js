import React, { forwardRef } from 'react'; //technique for automatically passing a ref through a component to one of its children. 
import { Helmet } from 'react-helmet'; // to set the title, description and meta tags for the document.
import PropTypes from 'prop-types';  // for Typechecking

const Page = forwardRef(({
  children,
  title = '',
  ...rest
}, ref) => {
  return (
    <div
      ref={ref}
      {...rest}
    >
      <Helmet>
        <title>{title}</title>
      </Helmet>
      {children}
    </div>
  );
});

Page.propTypes = {
  children: PropTypes.node.isRequired,
  title: PropTypes.string
};

export default Page;
