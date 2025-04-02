import { IconUsers, IconTrendingUp, IconMap } from '@tabler/icons-react';

export default function Home() {
  return (
    <div className="page-body">
      <div className="container-xl">
        <div className="row row-deck row-cards">
          {/* Stats Cards */}
          <div className="col-sm-6 col-lg-3">
            <div className="card">
              <div className="card-body">
                <div className="d-flex align-items-center">
                  <div className="subheader">Total Population</div>
                  <div className="ms-auto lh-1">
                    <IconUsers className="text-primary" />
                  </div>
                </div>
                <div className="h1 mb-3">267,894</div>
                <div className="d-flex mb-2">
                  <div>Growth rate</div>
                  <div className="ms-auto">
                    <span className="text-green d-inline-flex align-items-center lh-1">
                      7% <IconTrendingUp size={16} />
                    </span>
                  </div>
                </div>
              </div>
            </div>
          </div>
          
          {/* Main Content Area */}
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <h3 className="card-title">Population Distribution</h3>
              </div>
              <div className="card-body">
                <div className="d-flex align-items-center mb-3">
                  <IconMap className="me-2" />
                  <h4 className="m-0">Regional Overview</h4>
                </div>
                <p>Population distribution map and analytics will be displayed here.</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
