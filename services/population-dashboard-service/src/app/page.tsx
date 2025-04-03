'use client';

import { useEffect, useState } from 'react';
import { IconUsers, IconTrendingUp, IconMap } from '@tabler/icons-react';

export default function Home() {
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Simulate data loading
    const timer = setTimeout(() => {
      setLoading(false);
    }, 1000);

    return () => clearTimeout(timer);
  }, []);

  return (
    <div className="page-body">
      <div className="container-xl">
        <div className="row row-deck row-cards">
          {loading ? (
            <div className="col-12">
              <div className="card">
                <div className="card-body">
                  <div className="d-flex justify-content-center">
                    <div className="spinner-border text-blue" role="status">
                      <span className="visually-hidden">Loading...</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          ) : (
            <>
              <div className="col-sm-6 col-lg-3">
                <div className="card">
                  <div className="card-body">
                    <div className="d-flex align-items-center">
                      <div className="subheader">Total Population</div>
                      <div className="ms-auto lh-1">
                        <IconUsers className="text-primary" />
                      </div>
                    </div>
                    <div className="h1 mb-3">275.3M</div>
                    <div className="d-flex mb-2">
                      <div>Growth rate</div>
                      <div className="ms-auto">
                        <span className="text-green d-inline-flex align-items-center lh-1">
                          1.2% <IconTrendingUp size={16} />
                        </span>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-12">
                <div className="card">
                  <div className="card-header">
                    <h3 className="card-title">Population Overview</h3>
                  </div>
                  <div className="card-body">
                    <div className="d-flex align-items-center mb-3">
                      <IconMap className="me-2" />
                      <h4 className="m-0">Regional Overview</h4>
                    </div>
                    <p>Population data will be displayed here</p>
                  </div>
                </div>
              </div>
            </>
          )}
        </div>
      </div>
    </div>
  );
}
